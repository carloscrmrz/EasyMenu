using EasyMenu.Core.Model.Domains;

namespace EasyMenu.WebAPI.Model.Maps;

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
}