using EasyMenu.Core.Model.Domains;

namespace EasyMenu.Portal.Models.Maps;

public static class SectionMap
{
    public static SectionDto Map(this Section section)
    {
        return new SectionDto
        {
            SectionId = section.SectionId,
            SectionName = section.SectionName,
            ImageUrl = section.ImageUrl,
            Products = section.Products.Select(p => p.Map()),
        };
    }

    public static Section Map(this SectionDto section)
    {
        return new Section
        {
            SectionId = section.SectionId ?? 0,
            SectionName = section.SectionName,
            ImageUrl = section.ImageUrl,
            Products = section.Products.Select(p => p.Map()).ToHashSet()
        };
    }
}
