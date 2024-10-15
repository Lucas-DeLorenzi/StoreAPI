using Moq;
using Store.Application.Services;
using Store.Domain.Interfaces;
using Store.Domain.Entities;
using Store.Application.DTOs;
using AutoMapper;
using FluentAssertions;
using MediatR;

public class ProductServiceTests
{
    private readonly Mock<IProductCommandRepository> _productCommandRepositoryMock;
    private readonly Mock<IProductQueryRepository> _productQueryRepositoryMock;
    private readonly Mock<ICategoryQueryRepository> _categoryQueryRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly ProductService _productService;

    public ProductServiceTests()
    {
        _productCommandRepositoryMock = new Mock<IProductCommandRepository>();
        _productQueryRepositoryMock = new Mock<IProductQueryRepository>();
        _categoryQueryRepositoryMock = new Mock<ICategoryQueryRepository>();
        _mapperMock = new Mock<IMapper>();
        _productService = new ProductService(
            _productCommandRepositoryMock.Object,
            _productQueryRepositoryMock.Object,
            _categoryQueryRepositoryMock.Object,
            _mapperMock.Object);
    }

    [Fact]
    public async Task CreateProductAsync_ShouldReturnSuccessResponse()
    {

        var product = new Product
        {
            Id = 1,
            Name = "Producto1",
            Price = 100.50m,
            Quantity = 10,
            Description = "Descripcion de producto",
            CategoryId = 1
        };
        var productDto = new ProductDto
        {
            Id = 1,
            Name = "Producto1",
            Price = 100.50m,
            Quantity = 10,
            Description = "Descripcion de producto"
        };

        _mapperMock.Setup(m => m.Map<ProductDto>(product)).Returns(productDto);
        _productCommandRepositoryMock.Setup(r => r.CreateAsync(product)).Returns(Task.CompletedTask);


        var result = await _productService.CreateProductAsync(product);


        result.Success.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(productDto);
    }

    [Fact]
    public async Task GetProductByIdAsync_ShouldReturnProductWithCategory()
    {

        var product = new Product
        {
            Id = 1,
            Name = "Producto1",
            Price = 100.50m,
            Quantity = 10,
            Description = "Descripcion de producto",
            CategoryId = 1
        };
        var category = new Category
        {
            Id = 1,
            Name = "Categoria1",
            Description = "Descripcion de categoria"
        };
        var productWithCategoryDto = new ProductWithCategoryDTO
        {
            Id = 1,
            Name = "Producto1",
            Price = 100.50m,
            Quantity = 10,
            Description = "Descripcion de producto",
        };

        _productQueryRepositoryMock.Setup(r => r.GetByIdAsync(product.Id)).ReturnsAsync(product);
        _categoryQueryRepositoryMock.Setup(r => r.GetByIdAsync(product.CategoryId)).ReturnsAsync(category);
        _mapperMock.Setup(m => m.Map<ProductWithCategoryDTO>(product)).Returns(productWithCategoryDto);


        var result = await _productService.GetProductByIdAsync(product.Id);


        result.Success.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(productWithCategoryDto);
    }

    [Fact]
    public async Task DeleteProductAsync_ShouldReturnSuccessResponse()
    {

        var productId = 1;
        _productCommandRepositoryMock.Setup(r => r.DeleteAsync(productId)).Returns(Task.CompletedTask);


        var result = await _productService.DeleteProductAsync(productId);


        result.Success.Should().BeTrue();
        result.Data.Should().Be(Unit.Value);
    }

    [Fact]
    public async Task UpdateProductAsync_ShouldReturnUpdatedProduct()
    {
        var product = new Product
        {
            Id = 1,
            Name = "Producto Actualizado",
            Price = 150.75m,
            Quantity = 5,
            Description = "Descripcion de producto actualizada",
            CategoryId = 2
        };
        var productDto = new ProductDto
        {
            Id = 1,
            Name = "Producto Actualizado",
            Price = 150.75m,
            Quantity = 5,
            Description = "Descripcion de producto actualizada"
        };

        _productCommandRepositoryMock.Setup(r => r.UpdateAsync(product)).Returns(Task.CompletedTask);
        _mapperMock.Setup(m => m.Map<ProductDto>(product)).Returns(productDto);

        var result = await _productService.UpdateProductAsync(product);

        result.Success.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(productDto);
    }
}
