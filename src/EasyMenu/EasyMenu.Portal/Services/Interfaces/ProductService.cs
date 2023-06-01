´╗┐using EasyMenu.Core.Model;
using EasyMenu.Portal.Models;
using EasyMenu.Portal.Models.Maps;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.Portal.Services.Interfaces;

public class ProductService : IProductService
{
    private readonly EasyMenuContext _context;

    public ProductService(EasyMenuContext context)
    {
        _context = context;
    }

    public async Task<ProductDto> CreateProduct(ProductDto product)
    {
        var entity = product.Map();
        var entityEntry = _context.Products.Add(entity);
        await _context.SaveChangesAsync();

        var productDb = await _context.Products.FindAsync(entityEntry);
        return productDb?.Map() ?? product;
    }

    public Task<ProductDto> UpdateProduct(ProductDto product)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto> GetProduct(int productId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ProductDto>> GetAll(int tenantId)
    {
        var tenantMenus =
            _context.Menus.Where(m => m.TenantId == tenantId);
        var products = await tenantMenus
            .SelectMany(p =>
                p.Sections.SelectMany(s => s.Products))
            .ToListAsync();

        var productDtos = products.Select(p => p.Map());
        return productDtos;
    }

    public Task<bool> DeleteProduct(int productId)
    {
        throw new NotImplementedException();
    }
}