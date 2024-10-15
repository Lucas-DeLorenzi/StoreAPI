using MediatR;
using Store.Domain.Interfaces;
using Store.Application.Services.Interfaces;
using Store.Domain.Entities;
using Store.Application.DTOs;
using AutoMapper;
using Store.Domain.Common;

namespace Store.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductCommandRepository productCommandRepository, IProductQueryRepository productQueryRepository,
            ICategoryQueryRepository categoryQueryRepository, IMapper mapper)
        {
            _productCommandRepository = productCommandRepository;
            _productQueryRepository = productQueryRepository;
            _categoryQueryRepository = categoryQueryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ProductDto>> CreateProductAsync(Product product)
        {
            try
            {
                await _productCommandRepository.CreateAsync(product);

                var productDto = _mapper.Map<ProductDto>(product);

                return ServiceResponse<ProductDto>.SuccessResponse(productDto);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ProductDto>.FailureResponse($"An error occurred while creating the product: {ex.Message}");
            }
        }

        public async Task<ServiceResponse<ProductDto>> UpdateProductAsync(Product product)
        {
            try
            {
                await _productCommandRepository.UpdateAsync(product);
                var productDto = _mapper.Map<ProductDto>(product);
                return ServiceResponse<ProductDto>.SuccessResponse(productDto);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ProductDto>.FailureResponse($"An error occurred while updating the product: {ex.Message}");
            }
        }

        public async Task<ServiceResponse<Unit>> DeleteProductAsync(int id)
        {
            try
            {
                await _productCommandRepository.DeleteAsync(id);
                return ServiceResponse<Unit>.SuccessResponse(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.FailureResponse($"An error occurred while deleting the product: {ex.Message}");
            }
        }

        public async Task<ServiceResponse<ProductWithCategoryDTO>> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _productQueryRepository.GetByIdAsync(id);
                if (product == null)
                    return ServiceResponse<ProductWithCategoryDTO>.FailureResponse($"Product with id {id} not found");

                var category = await _categoryQueryRepository.GetByIdAsync(product.CategoryId);
                product.Category = category;
                var productWithCategoryDto = _mapper.Map<ProductWithCategoryDTO>(product);

                return ServiceResponse<ProductWithCategoryDTO>.SuccessResponse(productWithCategoryDto);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ProductWithCategoryDTO>.FailureResponse($"An error occurred: {ex.Message}");
            }
        }

        public async Task<ServiceResponse<IEnumerable<ProductDto>>> GetAllProductsAsync()
        {
            try
            {
                var products = await _productQueryRepository.GetAllAsync();
                var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
                return ServiceResponse<IEnumerable<ProductDto>>.SuccessResponse(productDtos);
            }
            catch (Exception ex)
            {
                return ServiceResponse<IEnumerable<ProductDto>>.FailureResponse($"An error occurred while fetching products: {ex.Message}");
            }
        }

        public async Task<ServiceResponse<IEnumerable<ProductDto>>> GetAllProductsByCategoryAsync(int categoryId)
        {
            try
            {
                var products = await _productQueryRepository.GetByCategoryIdAsync(categoryId);
                var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
                return ServiceResponse<IEnumerable<ProductDto>>.SuccessResponse(productDtos);
            }
            catch (Exception ex)
            {
                return ServiceResponse<IEnumerable<ProductDto>>.FailureResponse($"An error occurred while fetching products: {ex.Message}");
            }
        }
    }
}
