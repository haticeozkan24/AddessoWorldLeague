
namespace AdessoWorldLeague.Controllers.Responses;

public class GetGroupsResponse
{
    public string GroupName { get; set; }
    
    public List<TeamResponse> Teams { get; set; }
}