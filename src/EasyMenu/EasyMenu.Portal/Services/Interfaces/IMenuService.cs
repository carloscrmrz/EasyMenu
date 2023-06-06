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
    public Task<bool> DeleteMenu(int menuId);
}