using products.core.Entities;

namespace products.infrastructure.Repositories
{
    public interface IProductRepository
    {
        public Task<Product> GetProductByID(Guid prProductId);
        public Task<List<Product>> GetProductsByName(string srchString);
        public Task<bool> CreateProduct(Product prProduct);
        public Task<bool> DeleteProductByID(Guid prProduct);
        public Task<bool> UpdateProduct(Product prProduct);
        public Task<List<Product>> GetAllProducts();
    }
}