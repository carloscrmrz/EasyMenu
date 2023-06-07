using EasyMenu.Core.Model.Domains;
using EasyMenu.Portal.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyMenu.Portal.Services.Interfaces;

public interface IMenuService
{
    public Task<MenuDto> CreateMenu(MenuDto menu);
    public Task<MenuDto?> GetMenu(int menuId);
    public Task<IEnumerable<MenuDto>> GetAll(int tenantId);
    public Task<bool> UpdateMenu(MenuDto menu);
    public Task<bool> AddSectionToMenu(int menuId, int sectionId);
    public Task<bool> DeleteSectionFromMenu(int menuId, int sectionId);
    public Task<bool> MakeMenuPrincipal(int menuId, int tenantId);
    public Task<bool> DeleteMenu(int menuId);
}