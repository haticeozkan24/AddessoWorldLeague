using AdessoWorldLeague.Controllers;
using AdessoWorldLeague.Data.Enums;

namespace AdessoWorldLeague.Data.Entities;

public class Group
{
    public Guid Id { get; set; }
    
    public int Index { get; set; }
    public string Name { get; set; }
    
    public GroupType Type { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public string CreatedByName { get; set; }
    
    public string CreatedBySurname { get; set; }
}