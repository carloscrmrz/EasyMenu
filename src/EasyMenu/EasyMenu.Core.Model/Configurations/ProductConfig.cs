using EasyMenu.Core.Model.Domains;
using EasyMenu.Core.Model.Domains.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyMenu.Core.Model.Configurations;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Status)
            .HasConversion<int>();
        
        builder.SeedProducts();
    }
}