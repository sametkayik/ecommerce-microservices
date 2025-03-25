using AutoMapper;
using Ecommerce.Services.ProductAPI.dto;
using Ecommerce.Services.ProductAPI.Models;

namespace Ecommerce.Services.ProductAPI.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<VariantDto, Variant>()
            .ForMember(dest => dest.VariantId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.VariantId));
        
        CreateMap<ImageDto, Image>()
            .ForMember(dest => dest.ImageId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ImageId));
        
        CreateMap<ProductDto, Product>()
            .ForMember(dest => dest.ProductId, opt => opt.Ignore()) 
            .ForMember(dest => dest.Variants, opt => opt.MapFrom(src => src.Variants))
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
            .ReverseMap();
    }
}