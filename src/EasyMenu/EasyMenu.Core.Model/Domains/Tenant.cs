using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMenu.Core.Model.Enums;

namespace EasyMenu.Core.Model.Domains;

public class Tenant : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TenantId { get; set; }
    
    [Required]
    [Column(TypeName = "VARCHAR(200) COLLATE SQL_Latin1_General_CP1_CI_AS")]
    public string TenantName { get; set; }
    
    [Required]
    [Column(TypeName = "VARCHAR(200) COLLATE SQL_Latin1_General_CP1_CI_AS")]
    public string SubPath { get; set; }
    
    [Column(TypeName = "VARCHAR(200) COLLATE SQL_Latin1_General_CP1_CI_AS")]
    public string Address { get; set; }
    
    [Column(TypeName = "VARCHAR(200) COLLATE SQL_Latin1_General_CP1_CI_AS")]
    public string Telephone { get; set; }
    
    public Suscriptions ActiveSubscriptionId { get; set; }
    public int CurrentMenuId { get; set; }
    public Status Status{ get; set; }
    
    public int SuscriptionId { get; set; }
    public virtual Suscription Suscription { get; set; }
    public virtual ICollection<MenuUi> MenuUi { get; set; } = new HashSet<MenuUi>();
    public virtual ICollection<Menu> Menus { get; set; } = new HashSet<Menu>();
    public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
}