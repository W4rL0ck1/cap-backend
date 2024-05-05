using Cig.Cdu.Infrastructure.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using products.core.Entities;
using products.infrastructure.Repositories.Interfaces;

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

        public User GetUserByID(Guid prUserId){
            var user = _context.User
                                .Where(x => x.Id == prUserId)
                                .Include(x => x.Addresses)
                                .FirstOrDefault();
            return user;
        }
        public bool CreateUser(User prUser){
            try
            {
                var user = _userRepository.Create(prUser);
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message); // Aqui se implatando sistema de log, logar o erro;
                return false;
            }
        }
        public bool DeleteUserByID(Guid prUserId){
            try 
            {
                var user = _userRepository.GetById(prUserId);
                _userRepository.Delete(user);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); // Aqui se implatando sistema de log, logar o erro;
                return false;
            }
        }
        public bool UpdateUser(User prUser){
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
        public List<User> GetAllUsers(){
            var users = _context.User.ToList();
            return users;
        }
    }
}
