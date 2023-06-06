using EasyMenu.Core.Model;
using EasyMenu.Core.Model.Enums;
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

        var productDb = await _context.Products.FindAsync(entityEntry.Entity.ProductId);
        return productDb?.Map() ?? product;
    }

    public async Task<bool> UpdateProduct(ProductDto product)
    {
        var productId = product.ProductId;
        var entity = await _context.Products
            .FindAsync(productId);

        if (entity is null) return false;
        entity.ProductName = product.ProductName;
        entity.Price = product.Price;
        entity.Description = product.Description;
        entity.Position = product.Position;
        entity.Status = product.Status;

        var result = await _context.SaveChangesAsync();
        return result >= 1;
    }

    public async Task<bool> ChangeStatus(int productId)
    {
        var entity = await _context.Products
            .FindAsync(productId);

        if (entity is null) return false;

        entity.Status = entity.Status == Status.Active
            ? Status.Inactive
            : Status.Active;

        var result = await _context.SaveChangesAsync();
        return result >= 1;
    }

    public async Task<ProductDto> GetProduct(int productId)
    {
        var product = await _context.Products.FindAsync(productId);
        var productDto = product is null
            ? new ProductDto()
            : product.Map();
        return productDto;
    }

    public async Task<IEnumerable<ProductDto>> GetAll(int tenantId)
    {
        var products = await _context.Products
            .Where(p => p.TenantId == tenantId)
            .ToArrayAsync();

        var productDtos = products.Select(p => p.Map());
        return productDtos;
    }

    public async Task<bool> DeleteProduct(int productId)
    {
        var entity = await _context.Products
            .FindAsync(productId);

        if (entity is null) return false;
        entity.Status = Status.Inactive;

        var result = await _context.SaveChangesAsync();
        return result >= 1;
    }
}