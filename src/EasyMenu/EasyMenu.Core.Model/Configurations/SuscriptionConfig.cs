using EasyMenu.Core.Model.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyMenu.Core.Model.Configurations;

public class SuscriptionConfig :IEntityTypeConfiguration<Suscription>
{
    public void Configure(EntityTypeBuilder<Suscription> builder)
    {
        builder.HasMany(sus => sus.Tenants)
            .WithOne(t => t.Suscription)
            .HasForeignKey(t => t.SuscriptionId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.Property(sus => sus.SuscriptionType)
            .HasConversion<int>();
    }
}