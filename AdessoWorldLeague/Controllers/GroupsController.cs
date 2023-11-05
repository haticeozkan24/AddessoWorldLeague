using AdessoWorldLeague.Controllers.Requests;
using AdessoWorldLeague.Controllers.Responses;
using AdessoWorldLeague.Data;
using AdessoWorldLeague.Data.Entities;
using AdessoWorldLeague.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdessoWorldLeague.Controllers;

[ApiController]
[Route("team-groups")]
public class GroupsController : ControllerBase
{
    private readonly LeagueDbContext _leagueDbContext;

    public GroupsController(LeagueDbContext leagueDbContext)
    {
        _leagueDbContext = leagueDbContext;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> CreateGroups(CreateGroupsRequest request)
    {
        (int GroupCount, int GroupSize) = GetGroupCountAndSize(request.GroupType);
        
        Random random = new Random();

        for (int i = 0; i < GroupSize; i++)
        {
            for (int count = 1; count <= GroupCount; count++)
            {
                List<Guid> allGroupIds = await _leagueDbContext.Groups.Where(x => x.Type == request.GroupType)
                    .Select(x => x.Id).ToListAsync();

                Group group = await _leagueDbContext.Groups.FirstOrDefaultAsync(x => x.Type == request.GroupType && x.Index == count);

                if (group == null)
                {
                    group = new Group
                    {
                        Id = Guid.NewGuid(),
                        Name = $"Group {count}",
                        Index = count,
                        Type = request.GroupType,
                        CreatedAt = DateTime.Now,
                        CreatedByName = request.RequesterName,
                        CreatedBySurname = request.RequesterSurname
                    };

                    _leagueDbContext.Groups.Add(group);
                }
                else
                {
                    group.CreatedByName = request.RequesterName;
                    group.CreatedBySurname = request.RequesterSurname;
                    group.CreatedAt = DateTime.Now;
                }

                List<Guid> teamIdsInAllGroups = await _leagueDbContext.Teams
                    .Where(x => x.GroupId != null && allGroupIds.Contains(x.GroupId.Value)).Select(x => x.Id)
                    .ToListAsync();

                List<Guid> countryIdsOfCurrentGroupTeams = await _leagueDbContext.Teams
                    .Where(x => x.GroupId == group.Id).Select(x => x.CountryId).ToListAsync();

                List<Team> selectableTeams = await _leagueDbContext.Teams.Where(x =>
                    x.GroupId != group.Id && !countryIdsOfCurrentGroupTeams.Contains(x.CountryId) &&
                    !teamIdsInAllGroups.Contains(x.Id)).ToListAsync();

                Team team = selectableTeams.OrderBy(x => random.Next()).First();
                team.GroupId = group.Id;

                await _leagueDbContext.SaveChangesAsync();
            }
        }
        
        return Ok();
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetGroupsResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetGroups([FromQuery]GetGroupsRequest request)
    {
        List<Group> allGroups = await _leagueDbContext.Groups.Where(x => x.Type == request.GroupType).ToListAsync();
        List<Team> teamsInAllGroups = await _leagueDbContext.Teams.ToListAsync();
        
        List<GetGroupsResponse> response = new List<GetGroupsResponse>();

        foreach (Group group in allGroups)
        {
            List<Team> teams = teamsInAllGroups.Where(x => x.GroupId == group.Id).ToList();

            GetGroupsResponse getGroupsResponse = new GetGroupsResponse();
            getGroupsResponse.GroupName = group.Name;
            getGroupsResponse.Teams = new List<TeamResponse>();
            teams.ForEach(x => getGroupsResponse.Teams.Add(new TeamResponse
            {
                Name = x.Name
            }));
            
            response.Add(getGroupsResponse);
        }

        return Ok(response);
    }
    
    private (int GroupCount, int GroupSize) GetGroupCountAndSize(GroupType groupType)
    {
        switch (groupType)
        {
            case GroupType.FourTeam:
                return (4, 8);
            case GroupType.EightTeam:
                return (8, 4);
            default:
                throw new Exception($"Not implemented group type {groupType}");
        }
    }
}