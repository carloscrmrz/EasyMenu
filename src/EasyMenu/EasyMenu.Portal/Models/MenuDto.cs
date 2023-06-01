using EasyMenu.Core.Model.Enums;

namespace EasyMenu.Portal.Models;

public class MenuDto
{
    public int MenuId { get; set; }
    public int TenantId { get; set; }
    public Status Status { get; set; }
    public IEnumerable<SectionDto> Sections { get; set; }
}