using FavoretoAppX.Domain.Models;

namespace FavoretoAppX.Domain.Interfaces;

public interface IProductService
{
    public Task<List<Product>> GetAsync();
    public Task<Product> GetByIdAsync(string id);
    public Task CreateAsync(Product product);
    public Task UpdateAsync(Product product);
    public Task RemoveAsync(string id);
}