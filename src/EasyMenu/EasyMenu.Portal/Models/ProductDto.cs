using EasyMenu.Core.Model.Enums;

namespace EasyMenu.Portal.Models;

public class ProductDto
{
    public int? ProductId { get; set; }
    public int TenantId { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Position { get; set; }
    public Status Status { get; set; }
}