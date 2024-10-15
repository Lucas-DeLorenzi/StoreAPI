using AutoMapper;
using Store.Application.DTOs;
using Store.Application.Features.Categories.Commands;
using Store.Domain.Entities;

namespace Store.Application.Common.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}