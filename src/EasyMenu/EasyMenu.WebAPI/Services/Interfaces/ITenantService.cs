namespace EasyMenu.WebAPI.Services.Interfaces;

public interface ITenantService
{
    public Task<int> GetTenantIdFromTenantName(string name);
}