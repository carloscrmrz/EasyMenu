using EasyMenu.Core.Model.Domains;
using EasyMenu.Core.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyMenu.Core.Model.Configurations;

public class TenantConfig: IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.Property(t => t.StatusId)
            .HasDefaultValue(Status.Active)
            .HasConversion<int>();

        builder.Property(t => t.SubPath)
            .IsRequired()
            .HasDefaultValue(string.Empty);

        builder.Property(t => t.DateOfInsert)
            .HasColumnType("datetime")
            .HasDefaultValueSql("current_timestamp()");

        builder.HasOne(t => t.Suscription)
            .WithMany(sus => sus.Tenants)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasMany(t => t.MenuUi)
            .WithOne(m => m.Tenant)
            .HasForeignKey(m => m.MenuUiId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}