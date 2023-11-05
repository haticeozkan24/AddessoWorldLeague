using AdessoWorldLeague.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdessoWorldLeague.Data.Mappings;

public class CountryMap : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).IsRequired().HasColumnType("nvarchar(100)");
        builder.Property(p => p.CreatedAt).IsRequired().HasColumnType("datetime2(7)");
        builder.Property(p => p.CreatedBy).IsRequired().HasColumnType("nvarchar(100)");
    }
}