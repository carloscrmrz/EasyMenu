using EasyMenu.Core.Model.Domains;
using EasyMenu.Core.Model.Domains.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyMenu.Core.Model.Configurations;

public class SuscriptionConfig :IEntityTypeConfiguration<Suscription>
{
    public void Configure(EntityTypeBuilder<Suscription> builder)
    {
        builder.Property(sus => sus.SuscriptionType)
            .HasConversion<int>();

        builder.SeedSuscriptions();
    }
}