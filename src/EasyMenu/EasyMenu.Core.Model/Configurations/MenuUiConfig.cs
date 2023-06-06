using EasyMenu.Core.Model.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyMenu.Core.Model.Configurations;

public class MenuUiConfig : IEntityTypeConfiguration<MenuUi>
{
    public void Configure(EntityTypeBuilder<MenuUi> builder)
    {
        builder.Property(m => m.Status)
            .HasConversion<int>();
    }
}