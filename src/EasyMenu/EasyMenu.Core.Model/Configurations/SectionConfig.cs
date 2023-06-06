using EasyMenu.Core.Model.Domains;
using EasyMenu.Core.Model.Domains.Seeds;
using EasyMenu.Core.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyMenu.Core.Model.Configurations;

public class SectionConfig : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder.Property(t => t.Status)
            .HasDefaultValue(Status.Active)
            .HasConversion<int>();
        
        builder.SeedSections();
    }
}