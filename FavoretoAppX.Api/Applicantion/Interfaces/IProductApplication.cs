using FavoretoAppX.Domain.Models;

namespace FavoretoAppX.Api.Applicantion.Interfaces;

public interface IProductApplication
{
    public  Task<List<Product>> GetAsync();
    public  Task<Product> GetByIdAsync(string id);
    public  Task CreateAsync(Product product);
    public Task UpdateAsync(Product product);
    public Task RemoveAsync(string id);
    public Task<Product> GetBySkuAsync(string sku);
}