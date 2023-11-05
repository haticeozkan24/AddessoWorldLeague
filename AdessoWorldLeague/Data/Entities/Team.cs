namespace AdessoWorldLeague.Data.Entities;

public class Team
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public Guid CountryId { get; set; }
    
    public Guid? GroupId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public string CreatedBy { get; set; }
}