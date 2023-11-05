using AdessoWorldLeague.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdessoWorldLeague.Data;

public class LeagueDbContext :DbContext
{
    public LeagueDbContext(DbContextOptions<LeagueDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Country> Countries { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Team> Teams { get; set; }
}