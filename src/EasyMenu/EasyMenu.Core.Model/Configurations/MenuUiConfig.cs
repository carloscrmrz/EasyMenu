using EasyMenu.Core.Model.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyMenu.Core.Model.Configurations;

public class MenuUiConfig : IEntityTypeConfiguration<MenuUi>
{
    public void Configure(EntityTypeBuilder<MenuUi> builder)
    {
        builder.Property(m => m.StatusId)
            .HasConversion<int>();

        builder.HasOne(m => m.Tenant)
            .WithMany(t => t.MenuUi)
            .HasForeignKey(t => t.TenantId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}