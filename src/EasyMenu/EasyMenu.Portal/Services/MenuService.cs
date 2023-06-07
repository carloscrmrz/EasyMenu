using EasyMenu.Core.Model;
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

    public async Task<MenuDto> CreateMenu(MenuDto menu)
    {
        var entity = menu.Map();
        var entityEntry = _context.Menus.Add(entity);
        await _context.SaveChangesAsync();

        var menuDb = await _context.Menus.FindAsync(entityEntry.Entity.TenantId);
        return menuDb?.Map() ?? menu;
    }

    public async Task<MenuDto?> GetMenu(int menuId)
    {
        var menu = await _context.Menus
            .AsNoTracking()
            .Where(m => m.MenuId == menuId)
            .Include(m => m.Sections)
            .FirstOrDefaultAsync();

        return menu?.Map();
    }

    public async Task<IEnumerable<MenuDto>> GetAll(int tenantId)
    {
        var menus = await _context.Menus
            .Include(m => m.Tenant)
            .Include(m => m.Sections)
            .Where(m => m.TenantId == tenantId)
            .ToArrayAsync();

        var menuDtos = menus.Select(m => m.Map());
        return menuDtos;
    }

    public Task<bool> UpdateMenu(MenuDto menu)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddSectionToMenu(int menuId, int sectionId)
    {
        var menu = await _context.Menus
            .Include(m => m.Sections)
            .Where(m => m.MenuId == menuId)
            .FirstOrDefaultAsync();
        var section = await _context.Sections.FindAsync(sectionId);

        if (menu is null)
            return false;
        if (section is null || menu.Sections.Contains(section))
            return false;


        menu.Sections.Add(section);
        var result = await _context.SaveChangesAsync();

        return result >= 1;
    }

    public async Task<bool> DeleteSectionFromMenu(int menuId, int sectionId)
    {
        var menu = await _context.Menus
            .Include(m => m.Sections)
            .Where(m => m.MenuId == menuId)
            .FirstOrDefaultAsync();
        var section = await _context.Sections.FindAsync(sectionId);

        if (menu is null)
            return false;
        if (section is null || !menu.Sections.Contains(section))
            return false;


        menu.Sections.Remove(section);
        var result = await _context.SaveChangesAsync();

        return result >= 1;
    }

    public async Task<bool> MakeMenuPrincipal(int menuId, int tenantId)
    {
        var menus = await _context.Menus
            .Where(m => m.TenantId == tenantId)
            .ToListAsync();

        foreach (var menu in menus)
        {
            menu.Status = menu.MenuId == menuId
                ? Status.Active
                : Status.Inactive;
        }

        var result = await _context.SaveChangesAsync();
        return result >= 1;
    }

    public async Task<bool> DeleteMenu(int menuId)
    {
        var menu = await _context.Menus.FindAsync(menuId);

        if (menu is null)
            return true;

        menu.Status = Status.Inactive;
        var saved = await _context.SaveChangesAsync();
        return saved >= 1;
    }
}