using Cig.Cdu.Infrastructure.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using products.core.Entities;
using products.infrastructure.Repositories;

namespace products.infrastructure.Repositories
{
    
    public class UserRepository : IUserRepository
    {
        private Repository<User> _userRepository;
        private AppDbContext _context;

        public UserRepository(Repository<User> userRepository, AppDbContext context) {
            _userRepository = userRepository;
            _context=  context;
        }

        public async Task<User> GetUserByID(Guid prUserId){
            var user = await _context.User
                                .Where(x => x.Id == prUserId)
                                .Include(x => x.Addresses)
                                .FirstOrDefaultAsync();
            return user;
        }
        public async Task<User> GetUserByEmail(string prEmail){
            var user = await _context.User
                                .Where(x => x.Email == prEmail)
                                .Include(x => x.Addresses)
                                .FirstOrDefaultAsync();
            return user;
        }
        public async Task<bool> CreateUser(User prUser){
            try
            {
                var user = await _userRepository.CreateAsync(prUser);
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message); // Aqui se implatando sistema de log, logar o erro;
                return false;
            }
        }
        public async Task<bool> DeleteUserByID(Guid prUserId){
            try 
            {
                var user =  _userRepository.GetById(prUserId);
                _userRepository.Delete(user);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); // Aqui se implatando sistema de log, logar o erro;
                return false;
            }
        }
        public async Task<bool> UpdateUser(User prUser){
            try 
            {
                var user = _userRepository.Update(prUser);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); // Aqui se implatando sistema de log, logar o erro;
                return false;
            }
        }
        public async Task<List<User>> GetAllUsers(){
            var users = await _context.User.ToListAsync();
            return users;
        }
    }
}
