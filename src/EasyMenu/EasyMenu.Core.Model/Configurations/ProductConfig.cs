using EasyMenu.Core.Model.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyMenu.Core.Model.Configurations;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.StatusId)
            .HasConversion<int>();

        builder.HasMany(p => p.Sections)
            .WithMany(s => s.Products);

        builder.HasMany(p => p.ChildProducts)
            .WithOne(c => c.ParentProduct)
            .HasForeignKey(p => p.ParentProductId);
    }
}