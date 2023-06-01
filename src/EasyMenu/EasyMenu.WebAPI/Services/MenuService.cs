using EasyMenu.Core.Model;
using EasyMenu.Core.Model.Enums;
using EasyMenu.WebAPI.Model;
using EasyMenu.WebAPI.Model.Maps;
using EasyMenu.WebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.WebAPI.Services;

public class MenuService : IMenuService
{
    private readonly EasyMenuContext _context;

    public MenuService(EasyMenuContext context)
    {
        _context = context;
    }

    public async Task<MenuDto?> GetMenu(int tenantId)
    {
        var menus = await _context.Menus
            .AsNoTracking()
            .Where(m => m.Status == Status.Active)
            .Include(m => m.Sections)
            .ThenInclude(s => s.Products)
            .ToListAsync();

        var menu = menus.Find(m => m.TenantId == tenantId);
        return menu?.Map();
    }
}