using EasyMenu.Core.Model.Enums;

namespace EasyMenu.Portal.Models;

public class SectionDto
{
    public int? SectionId { get; set; }
    public string SectionName { get; set; }
    public string ImageUrl { get; set; }
    public Status Status { get; set; }
    public IEnumerable<ProductDto> Products { get; set; }
}