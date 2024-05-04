using Cig.Cdu.Infrastructure.Repositories;
using products.core.Entities;
using products.infrastructure.Repositories.Interfaces;

namespace products.infrastructure.Repositories
{
    
    public class UserRepository : IUserRepository
    {
        private Repository<User> _userRepository;
        public UserRepository(Repository<User> userRepository) {
            _userRepository = userRepository;
        }

        public User GetUserByID(Guid prUserId){
            return _userRepository.GetById(prUserId);
        }
        public bool DeleteUserByID(Guid prUserId){
            var user = _userRepository.GetById(prUserId);
            var deleted =  _userRepository.Delete(user);
            return true;
        }
        public List<User> GetAllUsers(){
            return _userRepository.GetAll().ToList();
        }
    }
}
