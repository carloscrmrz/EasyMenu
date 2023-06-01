namespace EasyMenu.WebAPI.Model;

public class MenuDto
{
    public int MenuId { get; set; }
    public IEnumerable<SectionDto> Sections { get; set; }
}