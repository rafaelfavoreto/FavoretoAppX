using FavoretoAppX.Domain.Interfaces;
using FavoretoAppX.Domain.Models;
using FluentValidation;

namespace FavoretoAppX.Service;

public class ProductService : IProductService
{
    //In this layer, the focus is on the business rules related to the product,
    //encompassing validations, calculations, and object modifications.
    //Interaction with the bank is handled by calling the infrastructure layer.

    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    #region CRUD
    //Handle bank return validations and deal with business rules
    public async Task<List<Product>> GetAsync()
    {
        return await _productRepository.GetAsync();
    }
    public async Task<Product> GetByIdAsync(string id)
    {
        return await _productRepository.GetByIdAsync(id);
    }
    public async Task CreateAsync(Product product)
    {
       
        await _productRepository.CreateAsync(product);
    }

    public async Task UpdateAsync(Product product)
    {        
        await _productRepository.UpdateAsync(product);
    }

    public async Task RemoveAsync(string id)
    {
        await _productRepository.RemoveAsync(id);
    }

    #endregion
}