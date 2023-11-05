using AdessoWorldLeague.Data;
using AdessoWorldLeague.Data.Entities;

namespace AdessoWorldLeague.Extensions;

public static class DbInitializer
{
    public static void Initialize(LeagueDbContext leagueDbContext)
    {
        leagueDbContext.Database.EnsureCreated();
        if (!leagueDbContext.Countries.Any() && !leagueDbContext.Teams.Any())
        {
            DateTime now = DateTime.UtcNow;
            string createdBy = nameof(DbInitializer);
            List<Country> countries = new List<Country>();

            Country turkey = new Country { Id = Guid.NewGuid(), Name = "Türkiye", CreatedAt = now, CreatedBy = createdBy };
            countries.Add(turkey);
            
            Country germany = new Country { Id = Guid.NewGuid(), Name = "Almanya", CreatedAt = now, CreatedBy = createdBy };
            countries.Add(germany);
            
            Country france = new Country { Id = Guid.NewGuid(), Name = "Fransa", CreatedAt = now, CreatedBy = createdBy };
            countries.Add(france);
            
            Country netherlands = new Country { Id = Guid.NewGuid(), Name = "Hollanda", CreatedAt = now, CreatedBy = createdBy };
            countries.Add(netherlands);
            
            Country portugal = new Country { Id = Guid.NewGuid(), Name = "Portekiz", CreatedAt = now, CreatedBy = createdBy };
            countries.Add(portugal);
            
            Country italy = new Country { Id = Guid.NewGuid(), Name = "İtalya", CreatedAt = now, CreatedBy = createdBy };
            countries.Add(italy);
            
            Country spain = new Country { Id = Guid.NewGuid(), Name = "İspanya", CreatedAt = now, CreatedBy = createdBy };
            countries.Add(spain);
            
            Country belgium = new Country { Id = Guid.NewGuid(), Name = "Belçika", CreatedAt = now, CreatedBy = createdBy };
            countries.Add(belgium);
            
            List<Team> teams = new List<Team>()
            {
                new() { Name = "Adesso İstanbul", CountryId = turkey.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Ankara", CountryId = turkey.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso İzmir", CountryId = turkey.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Antalya", CountryId = turkey.Id, CreatedAt = now, CreatedBy = createdBy },
               
                new() { Name = "Adesso Berlin", CountryId = germany.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Frankfurt", CountryId = germany.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Münih", CountryId = germany.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Dortmund", CountryId = germany.Id, CreatedAt = now, CreatedBy = createdBy },
                
                new() { Name = "Adesso Paris", CountryId = france.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Marsilya", CountryId = france.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Nice", CountryId = france.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Lyon", CountryId = france.Id, CreatedAt = now, CreatedBy = createdBy },
                
                new() { Name = "Adesso Amsterdam", CountryId = netherlands.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Rotterdam", CountryId = netherlands.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Lahey", CountryId = netherlands.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Eindhoven", CountryId = netherlands.Id, CreatedAt = now, CreatedBy = createdBy},
                
                new() { Name = "Adesso Lisbon", CountryId = portugal.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Porto", CountryId = portugal.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Braga", CountryId = portugal.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Coimbra", CountryId = portugal.Id, CreatedAt = now, CreatedBy = createdBy },
                
                new() { Name = "Adesso Roma", CountryId = italy.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Milano", CountryId = italy.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Venedik", CountryId = italy.Id, CreatedAt = now, CreatedBy = createdBy},
                new() { Name = "Adesso Napoli", CountryId = italy.Id, CreatedAt = now, CreatedBy = createdBy },
                
                new() { Name = "Adesso Sevilla", CountryId = spain.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Madrid", CountryId = spain.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Barselona", CountryId = spain.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Granada", CountryId = spain.Id, CreatedAt = now, CreatedBy = createdBy },
                
                new() { Name = "Adesso Brüksel", CountryId = belgium.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Brugge", CountryId = belgium.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Gent", CountryId = belgium.Id, CreatedAt = now, CreatedBy = createdBy },
                new() { Name = "Adesso Anvers", CountryId = belgium.Id, CreatedAt = now, CreatedBy = createdBy },
            };

            leagueDbContext.Countries.AddRange(countries);
            leagueDbContext.Teams.AddRange(teams);
            
            leagueDbContext.SaveChanges();
        }
    }
}