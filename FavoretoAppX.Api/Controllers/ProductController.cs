using FavoretoAppX.Api.Applicantion.Interfaces;
using FavoretoAppX.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FavoretoAppX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication _productApplication;

        public ProductController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProduct()
            => await _productApplication.GetAsync();
       
        [HttpGet("{id}")]
        public async Task<Product> GetByIdProduct(string id)
            => await _productApplication.GetByIdAsync(id);

        [HttpPost]
        public async Task<Product> CreateProduct([FromBody] Product product)
        {
            await _productApplication.CreateAsync(product);
            return product;
        }

        [HttpPut]
        public async Task<Product> UpdateProduct(Product product)
        {
            await _productApplication.UpdateAsync(product);
            return product;
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _productApplication.RemoveAsync(id);
        }
    }
}
