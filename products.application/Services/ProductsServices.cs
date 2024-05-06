using NetTopologySuite.Operation.Buffer;
using products.application.DTO;
using products.application.Interfaces.Generic;
using products.core.Entities;
using products.infrastructure.Repositories;
using Products.Application.Interfaces;

namespace products.application.Services
{
    public class ProductsServices: IProductsService
    {
        private readonly IProductRepository _prodRepository;
        private readonly IBaseResult _baseResult;
        public ProductsServices(IBaseResult baseResult, IProductRepository prodRepository){
            _baseResult = baseResult;
            _prodRepository = prodRepository;
        }

        #region Services
        public async Task<ResultDTO<List<Product>>> GetAllProducts(){
            List<Product> products =  new List<Product>();
            try
            {
                products = this.setDiscountInProducts(await _prodRepository.GetAllProducts());
                return _baseResult.returnResult(products, true, null);
            }
            catch (System.Exception ex)
            {
                return _baseResult.returnResult(products, true, $"Ocorreu um erro ao buscar os produtos! {ex}");
            }
        }   

        public async Task<ResultDTO<Product>> GetProductById(Guid prId){
            var product = await _prodRepository.GetProductByID(prId);

            if(product == null) return this._baseResult.returnResult(product, false, "Não foi encontrado produto com este ID!"); 

            product.Discount = this.setDiscount(product);

            return this._baseResult.returnResult(product, true, null); 
        }

        public async Task<ResultDTO<List<Product>>> GetProductsByName(string searchString){
            List<Product> products = new List<Product>();
            try
            {
                products = this.setDiscountInProducts(await _prodRepository.GetProductsByName(searchString));
                return _baseResult.returnResult(products, true, null);
            }
            catch (System.Exception ex)
            {
                return _baseResult.returnResult(products, true, $"Ocorreu um erro ao pesquisar os produtos!: {ex}");
            }
        }

        #endregion

        #region Bussiness And Utils
        private int setDiscount(Product product){
            //Aplicar regra dos descontos:
            //Se o desconto no produto for maior que o desconto da categoria aplicar o desconto do produto.
            int productDiscount = product.Discount;
            int categoryDiscount = product.Category.Discount;

            int finalDiscount = productDiscount > categoryDiscount ? productDiscount : categoryDiscount;
            return finalDiscount;
        }

        private List<Product> setDiscountInProducts(List<Product> prProducts){
            var productsWithNewDiscount = prProducts;
            Parallel.ForEach(productsWithNewDiscount, (product) => {
                product.Discount = this.setDiscount(product);
            });
            return productsWithNewDiscount;
        }
        #endregion    
    }
}