using AutoMapper;
using KarlaHi.Api.Dtos;
using KarlaHi.Infrastructure.Entities;

namespace KarlaHi.Api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
            .ForMember(m => m.ProductBrand, o => o.MapFrom(c => c.ProductBrand.Name))
            .ForMember(m => m.ProductType, o => o.MapFrom(c => c.ProductType.Name))
            .ForMember(m => m.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}