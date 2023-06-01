using EasyMenu.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.WebAPI.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        var mySqlVersion = new MySqlServerVersion(new Version(8, 0, 32));
        
        builder.Services
            .AddDbContext<EasyMenuContext>(optionsBuilder => 
                optionsBuilder.UseMySql(EasyMenuContext.ConnectionString, mySqlVersion))
            .RegisterServices()
            .AddControllers();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }
}