using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMenu.Core.Model.Enums;

namespace EasyMenu.Core.Model.Domains;

public class Menu : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MenuId { get; set; }
    
    [Required]
    public string TenantId { get; set; }
    
    public Status StatusId { get; set; }
    
    public Tenant Tenant { get; set; }
    public virtual ICollection<Section> Sections { get; set; } = new HashSet<Section>();
}