using EasyMenu.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyMenu.WebAPI.Controllers;

[Route("client-api/[controller]")]
[ApiController]
public class MenuController : ControllerBase
{
    private readonly ITenantService _tenantService;
    private readonly IMenuService _menuService;
    public MenuController(ITenantService tenantService, IMenuService menuService)
    {
        _tenantService = tenantService;
        _menuService = menuService;
    }
    [HttpGet("{name}")]
    public async Task<IActionResult> GetMenu(string name)
    {
        var tenantId = await _tenantService.GetTenantIdFromTenantName(name);
        var menu = await _menuService.GetMenu(tenantId);
        return menu is not null ? Ok(menu) : BadRequest();
    }
}