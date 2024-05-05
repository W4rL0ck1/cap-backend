using products.core.Entities;
using products.infrastructure.Repositories;

namespace Products.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository){
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByID(Guid UserID){
            var user = await _userRepository.GetUserByID(UserID);
            return user;
        }
    }
}