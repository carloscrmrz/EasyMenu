using EasyMenu.Core.Model.Enums;

namespace EasyMenu.WebAPI.Model;

public class ProductDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Position { get; set; }
}