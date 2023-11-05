using AdessoWorldLeague.Data.Enums;

namespace AdessoWorldLeague.Controllers.Requests;

public class GetGroupsRequest
{
    public GroupType GroupType { get; set; }
}