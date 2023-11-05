using AdessoWorldLeague.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdessoWorldLeague.Data.Mappings;

public class GroupMap: IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("Groups");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).IsRequired().HasColumnType("nvarchar(100)");
        builder.Property(p => p.Index).IsRequired().HasColumnType("int");
        builder.Property(p => p.Type).HasColumnType("int");
        builder.Property(p => p.CreatedAt).IsRequired().HasColumnType("datetime2(7)");
        builder.Property(p => p.CreatedByName).IsRequired().HasColumnType("nvarchar(100)");
        builder.Property(p => p.CreatedBySurname).IsRequired().HasColumnType("nvarchar(100)");
    }
}