using EasyMenu.WebAPI.Model;

namespace EasyMenu.WebAPI.Services.Interfaces;

public interface IMenuService
{
    public Task<MenuDto?> GetMenu(int tenantId);
}