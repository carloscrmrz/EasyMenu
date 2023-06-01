namespace EasyMenu.WebAPI.Model;

public class SectionDto
{
    public int? SectionId { get; set; }
    public string SectionName { get; set; }
    public string ImageUrl { get; set; }
    public IEnumerable<ProductDto> Products { get; set; }   
}