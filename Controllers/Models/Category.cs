namespace VShop.ProductApi.Controllers.Models;

public class Category
{

    public int CategoryId { get; set; }
    public string Name { get; set; }
    public ICollection<Product>? Products { get; set; }
}
