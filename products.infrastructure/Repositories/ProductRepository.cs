using Cig.Cdu.Infrastructure.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using products.core.Entities;
using products.infrastructure.Repositories;

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

        public async Task<Product> GetProductByID(Guid prProductId){
            var product = await _context.Products
                                .Where(x => x.Id == prProductId)
                                .Include(x => x.Category)
                                .FirstOrDefaultAsync();
            return product;
        }
        public async Task<List<Product>> GetProductsByName(string srchString){
            var products = await _context.Products
                                .Where(x => x.Name.Contains(srchString))
                                .Include(x => x.Category)
                                .ToListAsync();
            return products;
        }
        public async Task<bool> DeleteProductByID(Guid prProduct){
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
        public async Task<bool>  CreateProduct(Product prProduct){
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
        public async Task<bool>  UpdateProduct(Product prProduct){
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

        public async Task<List<Product>> GetAllProducts(){
            var products = await _context.Products
                                .Include(x => x.Category)
                                .ToListAsync();
            return products;
        }
    }
}
