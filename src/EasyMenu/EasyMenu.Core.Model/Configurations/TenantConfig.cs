using EasyMenu.Core.Model.Domains;
using EasyMenu.Core.Model.Domains.Seeds;
using EasyMenu.Core.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyMenu.Core.Model.Configurations;

public class TenantConfig: IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.Property(t => t.Status)
            .HasDefaultValue(Status.Active)
            .HasConversion<int>();

        builder.Property(t => t.SubPath)
            .IsRequired()
            .HasDefaultValue(string.Empty);

        builder.Property(t => t.DateOfInsert)
            .HasColumnType("datetime")
            .HasDefaultValueSql("current_timestamp()");
        
        builder.SeedTenants();
    }
}