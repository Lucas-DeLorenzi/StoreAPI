using MediatR;
using Store.Domain.Interfaces;
using Store.Application.Services.Interfaces;
using Store.Domain.Entities;
using AutoMapper;
using Store.Application.DTOs;
using Store.Domain.Common;

namespace Store.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryCommandRepository categoryCommandRepository, ICategoryQueryRepository categoryQueryRepository, IMapper mapper)
        {
            _categoryCommandRepository = categoryCommandRepository;
            _categoryQueryRepository = categoryQueryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CategoryDto>> CreateCategoryAsync(Category category)
        {
            try
            {
                await _categoryCommandRepository.CreateAsync(category);
                var categoryDto = _mapper.Map<CategoryDto>(category);
                return ServiceResponse<CategoryDto>.SuccessResponse(categoryDto);
            }
            catch (Exception ex)
            {
                return ServiceResponse<CategoryDto>.FailureResponse($"An error occurred while creating the category: {ex.Message}");
            }
        }

        public async Task<ServiceResponse<CategoryDto>> UpdateCategoryAsync(Category category)
        {
            try
            {
                await _categoryCommandRepository.UpdateAsync(category);
                var categoryDto = _mapper.Map<CategoryDto>(category);
                return ServiceResponse<CategoryDto>.SuccessResponse(categoryDto);
            }
            catch (Exception ex)
            {
                return ServiceResponse<CategoryDto>.FailureResponse($"An error occurred while updating the category: {ex.Message}");
            }
        }

        public async Task<ServiceResponse<Unit>> DeleteCategoryAsync(int id)
        {
            try
            {
                await _categoryCommandRepository.DeleteAsync(id);
                return ServiceResponse<Unit>.SuccessResponse(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.FailureResponse($"An error occurred while deleting the category: {ex.Message}");
            }
        }

        public async Task<ServiceResponse<CategoryDto>> GetCategoryByIdAsync(int id)
        {
            try
            {
                var category = await _categoryQueryRepository.GetByIdAsync(id);
                if (category == null)
                {
                    return ServiceResponse<CategoryDto>.FailureResponse($"Category with id {id} not found");
                }

                var categoryDto = _mapper.Map<CategoryDto>(category);
                return ServiceResponse<CategoryDto>.SuccessResponse(categoryDto);
            }
            catch (Exception ex)
            {
                return ServiceResponse<CategoryDto>.FailureResponse($"An error occurred while retrieving the category: {ex.Message}");
            }
        }

        public async Task<ServiceResponse<IEnumerable<CategoryDto>>> GetAllCategoriesAsync()
        {
            try
            {
                var categories = await _categoryQueryRepository.GetAllAsync();
                var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
                return ServiceResponse<IEnumerable<CategoryDto>>.SuccessResponse(categoriesDto);
            }
            catch (Exception ex)
            {
                return ServiceResponse<IEnumerable<CategoryDto>>.FailureResponse($"An error occurred while retrieving categories: {ex.Message}");
            }
        }
    }
}

