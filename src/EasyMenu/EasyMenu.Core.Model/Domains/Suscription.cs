using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyMenu.Core.Model.Enums;

namespace EasyMenu.Core.Model.Domains;

public class Suscription
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SuscriptionId { get; set; }

    [Required]
    public Suscriptions SuscriptionType { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    public double Discout { get; set; }
    public Status Status { get; set; }

    public ICollection<Tenant> Tenants { get; set; } = new HashSet<Tenant>();
}