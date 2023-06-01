using EasyMenu.Core.Model.Domains;

namespace EasyMenu.WebAPI.Model.Maps;

public static class MenuMap
{
    public static MenuDto Map(this Menu menu)
    {
        return new MenuDto()
        {
            MenuId = menu.MenuId,
            Sections = menu.Sections.Select(s => s.Map())
        };
    }
}