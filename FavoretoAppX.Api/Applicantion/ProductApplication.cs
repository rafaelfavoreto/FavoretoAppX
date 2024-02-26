using FavoretoAppX.Api.Applicantion.Interfaces;
using FavoretoAppX.Domain.Interfaces;
using FavoretoAppX.Domain.Models;
using FavoretoAppX.Infra.Repositories.Repositories;
using FluentValidation;

namespace FavoretoAppX.Api.Applicantion;
public class ProductApplication : IProductApplication
{
    private readonly IProductService _productService;
    private readonly IProductRepository _productRepository;

    // This class encompasses previous validations,
    // such as filters to check if the product exists,
    // among others. Therefore, the validations are in optimal condition,
    // allowing us to proceed to the next layer.
    public ProductApplication(IProductService productionService, IProductService productService, IProductRepository productRepository)
    {
        _productService = productService;
        _productRepository = productRepository;
    }

    #region CRUD

    public async Task<List<Product>> GetAsync()
    {
        return await _productService.GetAsync();
    }
    public async Task<Product> GetByIdAsync(string id)
    {
        return await _productService.GetByIdAsync(id);
    }
    public async Task CreateAsync(Product product)
    {
        product.Validate();
        await _productService.CreateAsync(product);
    }

    public async Task UpdateAsync(Product product)
    {
        product.Validate();
        await ValidationProductExist(product.Id);
        await _productService.UpdateAsync(product);
    }

    public async Task RemoveAsync(string id)
    {
        await ValidationProductExist(id);
        await _productService.RemoveAsync(id);
    }

    public async Task<Product> GetBySkuAsync(string sku)
    {
        await ValidationProductExistForSku(sku);
        throw new NotImplementedException();
    }

    #endregion

    #region Aux. Methodos

    private async Task ValidationProductExist(string id)
    {
        var existingProduct = await _productRepository.GetByIdAsync(id);
        if (existingProduct != null) throw new ValidationException("Product not found.");
    }

    private async Task ValidationProductExistForSku(string sku)
    {
        var existingProduct = await _productRepository.GetBySkuAsync(sku);
        if (existingProduct != null)
        {
            throw new ValidationException("A product with the same SKU already exists.");
        }
    }

    #endregion
}