using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EasyMenu.Core.Model;

public class EasyMenuContextDesignTimeFactory : IDesignTimeDbContextFactory<EasyMenuContext>
{
    public EasyMenuContext CreateDbContext(string[] args)
    {
        var mySqlVersion = new MySqlServerVersion(new Version(8, 0, 32));
        var connectionString = EasyMenuContext.ConnectionString;

        var options = new DbContextOptionsBuilder<EasyMenuContext>()
            .UseMySql(connectionString, mySqlVersion)
            .Options;
        return new EasyMenuContext(options);
    }
}