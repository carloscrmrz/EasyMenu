using EasyMenu.Core.Model.Domains;

namespace EasyMenu.Portal.Models.Maps;

public static class ProductMap
{
    public static ProductDto Map(this Product product)
    {
        return new ProductDto()
        {
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            Description = product.Description,
            Price = product.Price,
            Position = product.Position
        };
    }

    public static Product Map(this ProductDto product)
    {
        return new Product
        {
            ProductId = product.ProductId ?? 0,
            ProductName = product.ProductName,
            Description = product.Description,
            Price = product.Price,
            Position = product.Position,
        };
    }
}