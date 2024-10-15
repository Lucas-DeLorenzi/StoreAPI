﻿using AutoMapper;
using MediatR;
using Store.Application.DTOs;
using Store.Application.Services.Interfaces;
using Store.Domain.Common;
using Store.Domain.Entities;

namespace Store.Application.Features.Categories.Commands.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ServiceResponse<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            var result = await _categoryService.CreateCategoryAsync(category);
            return result;
        }
    }
}