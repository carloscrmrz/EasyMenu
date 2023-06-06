using EasyMenu.Core.Model.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyMenu.Core.Model.Domains.Seeds;

public static class ProductSeeder
{
    private static readonly ICollection<Product> Products = new Product[]
    {
        new()
        {
            ProductId = 1, TenantId = 1, ProductName = "Cerveza", Description = "La buena", Price = 3,
            Status = Status.Active
        },
        new()
        {
            ProductId = 2, TenantId = 1, ProductName = "Tomahawk", Description = "Ta jugoso", Price = 29,
            Status = Status.Active
        },
        new()
        {
            ProductId = 3, TenantId = 1, ProductName = "Cafe", Description = "Te despierta", Price = 1,
            Status = Status.Active
        },
        new()
        {
            ProductId = 4, TenantId = 1, ProductName = "Calamares", Description = "Los que hacen glu glu", Price = 11,
            Status = Status.Active
        }
    };

    public static void SeedProducts(this EntityTypeBuilder<Product> builder)
    {
        builder.HasData(Products);
    }
}