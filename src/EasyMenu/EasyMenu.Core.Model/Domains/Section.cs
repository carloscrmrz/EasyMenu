using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMenu.Core.Model.Enums;

namespace EasyMenu.Core.Model.Domains;

public class Section
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SectionId { get; set; }
    
    public int TenantId { get; set; }
    public virtual Tenant Tenant { get; set; }
    
    public string SectionName { get; set; }
    public string ImageUrl { get; set; }
    public Status Status { get; set; }

    public virtual ICollection<Product> Products { get; set; } =
        new HashSet<Product>();
    public virtual ICollection<Menu> Menus { get; set; } =
        new HashSet<Menu>();
}