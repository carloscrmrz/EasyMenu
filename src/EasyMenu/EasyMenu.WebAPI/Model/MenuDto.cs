using EasyMenu.Core.Model.Enums;

namespace EasyMenu.WebAPI.Model;

public class MenuDto
{
    public int MenuId { get; set; }
    public Status StatusId { get; set; }
    public ICollection<SectionDto> Sections { get; set; }
}