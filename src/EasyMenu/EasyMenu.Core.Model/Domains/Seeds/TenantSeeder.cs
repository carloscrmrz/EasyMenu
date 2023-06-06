using EasyMenu.Core.Model.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyMenu.Core.Model.Domains.Seeds;

public static class TenantSeeder
{
    private static readonly ICollection<Tenant> Tenants = new Tenant[]
    {
        new()
        {
            TenantId = 1, TenantName = "EasyMenu", SubPath = "easymenu", Address = "", Telephone = "123",
            ActiveSubscriptionId = Suscriptions.PaidOneRest, CurrentMenuId = 1, Status = Status.Active, SuscriptionId = 1
        },
    };
    
    public static void SeedTenants(this EntityTypeBuilder<Tenant> builder)
    {
        builder.HasData(Tenants);
    }
}