using FavoretoAppX.Domain.Interfaces;
using FavoretoAppX.Domain.Models;
using FavoretoAppX.Infra.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace FavoretoAppX.Infra.Repositories.Repositories;

public class ProductRepository : IProductRepository
{
    //At this level, it interfaces directly with the bank,
    //handling validations it needs to return, among other tasks.

    private readonly IMongoCollection<Product> _productCollection;
    public ProductRepository(IOptions<ProductDataBaseSettings> produtoServices)
    {
        var mongoClient = new MongoClient(produtoServices.Value.ConnectionString);
        var mongoDataBase = mongoClient.GetDatabase(produtoServices.Value.DataBaseName);

        _productCollection = mongoDataBase.GetCollection<Product>(produtoServices.Value.ProductCollection);
    }
    public async Task<List<Product>> GetAsync() => await _productCollection.Find(x => true).ToListAsync();
    public async Task<Product> GetByIdAsync(string id) => await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    public async Task CreateAsync(Product product) => await _productCollection.InsertOneAsync(product);
    public async Task UpdateAsync(Product product) => await _productCollection.ReplaceOneAsync(x => x.Id == product.Id, product);
    public async Task RemoveAsync(string id) => await _productCollection.DeleteOneAsync(x => x.Id == id);
    public async Task<Product> GetBySkuAsync(string sku) => await _productCollection.Find(x => x.Sku == sku).FirstOrDefaultAsync();
  
}
