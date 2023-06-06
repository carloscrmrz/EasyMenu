using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMenu.Core.Model.Enums;

namespace EasyMenu.Core.Model.Domains;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }
    
    public int TenantId { get; set; }
    public virtual Tenant Tenant { get; set; }

    
    public int? ParentProductId { get; set; }
    
    [Required]
    [Column(TypeName = "VARCHAR(200) COLLATE SQL_Latin1_General_CP1_CI_AS")]
    public string ProductName { get; set; }

    [Column(TypeName = "VARCHAR(200) COLLATE SQL_Latin1_General_CP1_CI_AS")]
    public string Description { get; set; }
    
    public decimal Price { get; set; }
    public int Position { get; set; }
    public Status Status { get; set; }

    public virtual ICollection<Product> ChildProducts { get; set; } = new HashSet<Product>();
    public virtual Product ParentProduct { get; set; }
    public virtual ICollection<Section> Sections { get; set; } = new HashSet<Section>();
}