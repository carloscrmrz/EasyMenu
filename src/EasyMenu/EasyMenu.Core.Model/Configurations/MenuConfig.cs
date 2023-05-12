using EasyMenu.Core.Model.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyMenu.Core.Model.Configurations;

public class MenuConfig : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.Property(m => m.StatusId)
            .HasConversion<int>();

        builder.HasOne(m => m.Tenant)
            .WithMany(t => t.Menus)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasMany(m => m.Sections)
            .WithMany(s => s.Menus);
    }
}