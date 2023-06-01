using EasyMenu.Core.Model;
using EasyMenu.Core.Model.Domains;
using EasyMenu.Core.Model.Enums;
using EasyMenu.Portal.Models;
using EasyMenu.Portal.Models.Maps;
using EasyMenu.Portal.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.Portal.Services;

public class MenuService : IMenuService
{
    private readonly EasyMenuContext _context;

    public MenuService(EasyMenuContext context)
    {
        _context = context;
    }

    public Task<MenuDto> CreateMenu(MenuDto menu)
    {
        // var saved = _context.Menus.AddAsync();
        _context.SaveChangesAsync();
        return Task.FromResult(menu);
    }

    public async Task<MenuDto?> GetMenu(int tenantId)
    {
        var menus = await _context.Menus
            .AsNoTracking()
            .Include(m => m.Sections)
            .ThenInclude(s => s.Products)
            .ToListAsync();

        var menu = menus.Find(m => m.Tenant.TenantId == tenantId);
        return menu?.Map();
    }

    public Task<MenuDto> UpdateMenu(MenuDto menu)
    {
        return Task.FromResult(menu);
    }

    public async Task<bool> DeleteMenu(int menuId)
    {
        var menu = await _context.Menus.FindAsync(menuId);

        if (menu is null)
            return true;

        menu.Status = Status.Inactive;
        var saved = await _context.SaveChangesAsync();
        return saved > 0;

    }
}