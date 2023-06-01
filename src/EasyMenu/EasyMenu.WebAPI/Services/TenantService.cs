using EasyMenu.Core.Model;
using EasyMenu.WebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.WebAPI.Services;

public class TenantService : ITenantService
{
    private readonly EasyMenuContext _context;
    public TenantService(EasyMenuContext context)
    {
        _context = context;
    }

    public async Task<int> GetTenantIdFromTenantName(string name)
    {
        var tenantId = await _context.Tenants
            .Where(t => t.TenantName == name)
            .Select(t => t.TenantId)
            .FirstOrDefaultAsync();

        return tenantId;
    }
}