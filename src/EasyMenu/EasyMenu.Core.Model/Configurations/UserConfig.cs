using EasyMenu.Core.Model.Domains;
using EasyMenu.Core.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyMenu.Core.Model.Configurations;

public class UserConfig: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.DateOfInsert)
            .HasColumnType("datetime")
            .HasDefaultValueSql("current_timestamp()");

        builder.Property(u => u.Locked)
            .HasDefaultValue(false);

        builder.Property(u => u.TemporaryLocked)
            .HasDefaultValue(false);
        
        builder.Property(u => u.StatusId)
            .HasDefaultValue(Status.Active)
            .HasConversion<int>();

        builder.HasOne(u => u.Tenant)
            .WithMany(t => t.Users)
            .HasForeignKey(u => u.TenantId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}