using products.core.Entities;

namespace products.infrastructure.Repositories
{
    public interface IProductRepository
    {
        public Product GetProductByID(Guid prProductId);
        public bool CreateProduct(Product prProduct);
        public bool DeleteProductByID(Guid prProduct);
        public bool UpdateProduct(Product prProduct);
        public List<Product> GetAllProducts();
    }
}