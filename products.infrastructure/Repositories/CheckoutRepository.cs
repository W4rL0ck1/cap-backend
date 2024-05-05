using Cig.Cdu.Infrastructure.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using products.core.Entities;
using products.infrastructure.Repositories.Interfaces;

namespace ckeckouts.infrastructure.Repositories
{
    
    public class ckeckoutRepository : ICkeckoutRepository
    {
        private Repository<Checkout> _ckeckoutRepository;
        private AppDbContext _context;

        public ckeckoutRepository(Repository<Checkout> ckeckoutRepository, AppDbContext context) {
            _ckeckoutRepository = ckeckoutRepository;
            _context=  context;
        }

        public Checkout GetCheckoutByID(Guid prckeckoutId){
            var ckeckout = _context.Checkout
                                .Where(x => x.Id == prckeckoutId)
                                .Include(x => x.Products)
                                .FirstOrDefault();
            return ckeckout;
        }
        public bool CreateCkeckout(Checkout prCheckout){
            try
            {
                var ckeckout = _ckeckoutRepository.Create(prCheckout);
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message); // Aqui se implatando sistema de log, logar o erro;
                return false;
            }
        }
        public bool DeleteCheckoutByID(Guid prckeckout){
            try 
            {
                var checkout = _ckeckoutRepository.GetById(prckeckout);
                _ckeckoutRepository.Delete(checkout);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); // Aqui se implatando sistema de log, logar o erro;
                return false;
            }
        }
        public bool UpdateCheckout(Checkout prckeckout){
            try 
            {
                var ckeckout = _ckeckoutRepository.Update(prckeckout);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); // Aqui se implatando sistema de log, logar o erro;
                return false;
            }
        }

        public List<Checkout> GetAllCheckouts(){
            var ckeckouts = _context.Checkout
                                .Include(x => x.Products)
                                .ToList();
            return ckeckouts;
        }
    }
}
