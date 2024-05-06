using products.application.DTO;
using products.core.Entities;

namespace Products.Application.Interfaces
{
    public interface IProductsService
    {
        public Task<ResultDTO<List<Product>>> GetAllProducts();
        public Task<ResultDTO<Product>> GetProductById(Guid prId);
        public Task<ResultDTO<List<Product>>> GetProductsByName(string searchString);
    }
}
