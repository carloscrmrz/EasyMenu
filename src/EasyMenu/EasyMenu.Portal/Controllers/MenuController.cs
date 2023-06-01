using EasyMenu.Portal.Models;
using EasyMenu.Portal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyMenu.Portal.Controllers;

[ApiController]
[Route("[controller]")]
public class MenuController: ControllerBase
{
    private readonly IMenuService _menuService;
    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }

    [HttpGet("{tenantId:int}")]
    public async Task<IActionResult> GetMenu(int tenantId)
    {
        var menu = await _menuService.GetMenu(tenantId);

        if (menu is null)
            return NotFound();
        return Ok(menu);
    }

    [HttpPost]
    public async Task<IActionResult> NewMenu(MenuDto menu)
    {
        var newMenu = await _menuService.CreateMenu(menu);
        return Ok(newMenu);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMenu(MenuDto menu)
    {
        var updatedMenu = await _menuService.UpdateMenu(menu);
        return Ok(updatedMenu);
    }

    [HttpPut("{menuId:int}")]
    public async Task<IActionResult> DeleteMenu(int menuId)
    {
        var successfulDelete = await _menuService.DeleteMenu(menuId);
        return successfulDelete ? Ok() : StatusCode(500);
    }
}