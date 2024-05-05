using Cig.Cdu.Infrastructure.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using products.core.Entities;
using products.infrastructure.Repositories;

namespace ckeckouts.infrastructure.Repositories
{
    
    public class CkeckoutRepository : ICkeckoutRepository
    {
        private Repository<Checkout> _ckeckoutRepository;
        private AppDbContext _context;

        public CkeckoutRepository(Repository<Checkout> ckeckoutRepository, AppDbContext context) {
            _ckeckoutRepository = ckeckoutRepository;
            _context=  context;
        }

        public async Task<Checkout> GetCheckoutByID(Guid prckeckoutId){
            var ckeckout = await _context.Checkout
                                .Where(x => x.Id == prckeckoutId)
                                .Include(x => x.Products)
                                .FirstOrDefaultAsync();
            return ckeckout;
        }
        public async Task<bool> CreateCkeckout(Checkout prCheckout){
            try
            {
                var ckeckout = await _ckeckoutRepository.CreateAsync(prCheckout);
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message); // Aqui se implatando sistema de log, logar o erro;
                return false;
            }
        }
        public async Task<bool>  DeleteCheckoutByID(Guid prckeckout){
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
        public async Task<bool>  UpdateCheckout(Checkout prckeckout){
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

        public async Task<List<Checkout>> GetAllCheckouts(){
            var ckeckouts = await _context.Checkout
                                .Include(x => x.Products)
                                .ToListAsync();
            return ckeckouts;
        }
    }
}
