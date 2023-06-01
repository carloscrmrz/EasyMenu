´╗┐using EasyMenu.Core.Model.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyMenu.Core.Model.Domains.Seeds;

public static class MenuSeeder
{
    private static readonly ICollection<Menu> Menus = new Menu[]
    {
        new() { MenuId = 1, Status = Status.Active, TenantId = 1, DateOfInsert = DateTime.Now, EnteredByUserId = 1},
        new() { MenuId = 2, Status = Status.Inactive, TenantId = 1, DateOfInsert = DateTime.Now, EnteredByUserId = 1}
    };

    public static void SeedMenu(this EntityTypeBuilder<Menu> builder)
    {
        builder.HasData(Menus);
    }
}