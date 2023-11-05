using AdessoWorldLeague.Data;

namespace AdessoWorldLeague.Extensions;

public static class DbInitializerExtension
{
    public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
    {
        using (IServiceScope scope = app.ApplicationServices.CreateScope())
        {
            LeagueDbContext leagueDbContext = scope.ServiceProvider.GetRequiredService<LeagueDbContext>();
            
            DbInitializer.Initialize(leagueDbContext);
        }

        return app;
    }
}