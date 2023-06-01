using EasyMenu.Core.Model.Domains;

namespace EasyMenu.WebAPI.Model.Maps;

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
}
