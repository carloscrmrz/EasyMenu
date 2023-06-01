using EasyMenu.Core.Model.Domains;
using EasyMenu.Portal.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyMenu.Portal.Services.Interfaces;

public interface IMenuService
{
    public Task<MenuDto> CreateMenu(MenuDto menu);
    public Task<MenuDto?> GetMenu(int tenantId);
    public Task<MenuDto> UpdateMenu(MenuDto menu);
    public Task<bool> DeleteMenu(int menuId);
}