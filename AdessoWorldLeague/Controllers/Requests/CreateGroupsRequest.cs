using AdessoWorldLeague.Data.Enums;

namespace AdessoWorldLeague.Controllers.Requests;

public class CreateGroupsRequest
{
    public string RequesterName { get; set; }
    
    public string RequesterSurname { get; set; }
    
    public GroupType GroupType { get; set; }
}