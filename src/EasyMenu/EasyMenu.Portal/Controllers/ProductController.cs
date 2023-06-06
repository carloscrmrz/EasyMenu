using EasyMenu.Portal.Models;
using EasyMenu.Portal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyMenu.Portal.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController: ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAll(1);
        return Ok(products);
    }

    [HttpGet("{productId:int}")]
    public async Task<IActionResult> GetProduct(int productId)
    {
        var product = await _productService.GetProduct(productId);
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductDto productDto)
    {
        var product = await _productService.CreateProduct(productDto);
        return Ok(product);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(ProductDto product)
    {
        var result = await _productService.UpdateProduct(product);
        return result ? Ok() : BadRequest();
    }
    
    [HttpDelete("{productId:int}")]
    public async Task<IActionResult> DeleteProduct(int productId)
    {
        var result = await _productService.DeleteProduct(productId);
        return result ? Ok() : BadRequest();
    }
}