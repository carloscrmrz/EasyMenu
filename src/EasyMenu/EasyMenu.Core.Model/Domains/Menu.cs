using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMenu.Core.Model.Enums;

namespace EasyMenu.Core.Model.Domains;

public class Menu : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MenuId { get; set; }
    
    public Status Status { get; set; }
    public int TenantId { get; set; }
    public virtual Tenant Tenant { get; set; }
    public virtual ICollection<Section> Sections { get; set; } = new HashSet<Section>();
}