using EasyMenu.WebAPI.Services;
using EasyMenu.WebAPI.Services.Interfaces;

namespace EasyMenu.WebAPI.Extensions;

public static class ServiceBuilderExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ITenantService, TenantService>();
        services.AddScoped<IMenuService, MenuService>();

        
        return services;
    }
}