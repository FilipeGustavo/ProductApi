namespace VShop.ProductApi.Controllers.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal price { get; set; }
    public string? Description { get; set; }
    public long Stock { get; set; }
    public string? ImageURL { get; set; }

    public Category? caterory { get; set; }
    public int categoryId { get; set; }
}
