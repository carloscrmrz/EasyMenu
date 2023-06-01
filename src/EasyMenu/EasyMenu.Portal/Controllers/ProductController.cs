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
}