using Cig.Cdu.Infrastructure.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using products.core.Entities;
using products.infrastructure.Repositories.Interfaces;

namespace products.infrastructure.Repositories
{
    
    public class ProductRepository : IProductRepository
    {
        private Repository<Product> _productRepository;
        private AppDbContext _context;

        public ProductRepository(Repository<Product> productRepository, AppDbContext context) {
            _productRepository = productRepository;
            _context=  context;
        }

        public Product GetProductByID(Guid prProductId){
            var product = _context.Products
                                .Where(x => x.Id == prProductId)
                                .Include(x => x.Category)
                                .FirstOrDefault();
            return product;
        }
        public bool DeleteProductByID(Guid prProduct){
            try 
            {
                var product = _productRepository.GetById(prProduct);
                _productRepository.Delete(product);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); // Aqui se implatando sistema de log, logar o erro;
                return false;
            }
        }
        public bool CreateProduct(Product prProduct){
            try
            {
                var ckeckout = _productRepository.Create(prProduct);
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message); // Aqui se implatando sistema de log, logar o erro;
                return false;
            }
        }
        public bool UpdateProduct(Product prProduct){
            try 
            {
                var product = _productRepository.Update(prProduct);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); // Aqui se implatando sistema de log, logar o erro;
                return false;
            }
        }

        public List<Product> GetAllProducts(){
            var products = _context.Products
                                .Include(x => x.Category)
                                .ToList();
            return products;
        }
    }
}
