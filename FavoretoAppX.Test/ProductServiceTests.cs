using FavoretoAppX.Domain.Enum;
using FavoretoAppX.Domain.Interfaces;
using FavoretoAppX.Domain.Models;
using FavoretoAppX.Service;
using Moq;

namespace FavoretoAppX.Test
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task GetProducts_ShouldReturnListOfProducts()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            mockRepository.Setup(repo => repo.GetAsync())
                .ReturnsAsync(new List<Product>
                {
                    new("Product 1", 10.0m, ProductStatusEnum.Active, "SKU001", 100),
                    new("Product 2", 20.0m, ProductStatusEnum.Active, "SKU002", 50)
                });

            var productService = new ProductService(mockRepository.Object);

            // Act
            var result = await productService.GetAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}