using App.Api.Models;
using App.Domain;
using AutoMapper;

namespace App.Api.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
