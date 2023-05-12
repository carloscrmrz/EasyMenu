using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMenu.Core.Model.Enums;

namespace EasyMenu.Core.Model.Domains;

public class MenuUi
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MenuUiId { get; set; }
    
    public int TenantId { get; set; }
    public string AssetPath { get; set; }
    public Status StatusId { get; set; }
    
    public virtual Tenant Tenant { get; set; }
}