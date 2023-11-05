using AdessoWorldLeague.Data;
using AdessoWorldLeague.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<LeagueDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LeagueDB"),
        sqlOptions => sqlOptions.EnableRetryOnFailure(3));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.SeedDatabase();

app.Run();