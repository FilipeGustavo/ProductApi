using AutoMapper;
using VShop.ProductApi.Controllers.Models;

namespace VShop.ProductApi.DTO.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        } 
    }
}
