namespace AdessoWorldLeague.Data.Entities;

public class Country
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public string CreatedBy { get; set; }
}