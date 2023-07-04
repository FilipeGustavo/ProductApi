using System.ComponentModel.DataAnnotations;
using VShop.ProductApi.Controllers.Models;

namespace VShop.ProductApi.DTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        public ICollection<ProductDTO>? Products { get; set; }
    }
}
