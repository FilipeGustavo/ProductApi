using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VShop.ProductApi.Controllers.Models;

namespace VShop.ProductApi.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [MinLength (3)]
        [MaxLength(100)]
        public string? Description { get; set; }
        [Required(ErrorMessage = "O estoqe é obrigatório.")]
        [Range(1, 9999)]
        public long Stock { get; set; }
        public string? ImageURL { get; set; }
        [JsonIgnore]
        public Category? caterory { get; set; }
        public int categoryId { get; set; }
    }
}
