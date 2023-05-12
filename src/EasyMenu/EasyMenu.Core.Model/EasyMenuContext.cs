using System.Transactions;
using EasyMenu.Core.Model.Configurations;
using EasyMenu.Core.Model.Domains;
using EasyMenu.Core.Model.Helpers;
using Microsoft.EntityFrameworkCore;

namespace EasyMenu.Core.Model;

public class EasyMenuContext: DbContext
{
    public const string SectionName = "DBConnectionConfig";
    
    public static readonly string ConnectionString =
        ConfigurationHelpers.GetConnectionString(SectionName);
    
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Tenant> Tenants { get; set; }
    public virtual DbSet<Suscription> Suscriptions { get; set; }
    public virtual DbSet<Menu> Menus  { get; set; }
    public virtual DbSet<MenuUi> MenuUis  { get; set; }
    public virtual DbSet<Section> Sections  { get; set; }
    public virtual DbSet<Product> Products  { get; set; }

    public EasyMenuContext(DbContextOptions<EasyMenuContext> contextOptions) : base(contextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MenuConfig());
        modelBuilder.ApplyConfiguration(new MenuUiConfig());
        modelBuilder.ApplyConfiguration(new ProductConfig());
        modelBuilder.ApplyConfiguration(new SectionConfig());
        modelBuilder.ApplyConfiguration(new SuscriptionConfig());
        modelBuilder.ApplyConfiguration(new TenantConfig());
        modelBuilder.ApplyConfiguration(new UserConfig());

    }
}
