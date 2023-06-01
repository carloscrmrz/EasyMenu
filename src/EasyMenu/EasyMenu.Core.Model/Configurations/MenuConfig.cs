using EasyMenu.Core.Model.Domains;
using EasyMenu.Core.Model.Domains.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyMenu.Core.Model.Configurations;

public class MenuConfig : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.Property(m => m.Status)
            .HasConversion<int>();

        builder.SeedMenu();
    }
}