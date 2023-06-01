using EasyMenu.Portal.Models;

namespace EasyMenu.Portal.Services.Interfaces;

public interface IProductService
{
    public Task<ProductDto> CreateProduct(ProductDto product);
    public Task<ProductDto> UpdateProduct(ProductDto product);
    public Task<ProductDto> GetProduct(int productId);
    public Task<IEnumerable<ProductDto>> GetAll(int tenantId);
    public Task<bool> DeleteProduct(int productId);
}