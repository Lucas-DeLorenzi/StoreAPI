using AutoMapper;
using Store.Application.DTOs;
using Store.Application.Features.Products.Commands;
using Store.Domain.Entities;

namespace Store.Application.Common.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<ProductWithCategoryDTO, Product>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
