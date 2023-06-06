using System.Collections.Immutable;
using EasyMenu.Core.Dtos;
using EasyMenu.Core.Model.Domains;

namespace EasyMenu.Portal.Models.Maps;

public static class MenuMap
{
    public static MenuDto Map(this Menu menu)
    {
        return new MenuDto()
        {
            MenuId = menu.MenuId,
            TenantId = menu.TenantId,
            Sections = menu.Sections.Select(s => s.Map())
        };
    }

    public static Menu Map(this MenuDto menu)
    {
        return new Menu
        {
            MenuId = menu.MenuId,
            Sections = menu.Sections.Select(s => s.Map()).ToHashSet(),
        };
    }
}