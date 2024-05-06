using products.core.Entities;
using products.infrastructure.Repositories;
using Products.Application.DTO;
using Products.Application.Interfaces;
using SQLitePCL;

namespace Products.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurityService _securityService;
        private readonly IJwtService _jwtService;
        public UserService(IUserRepository userRepository,
                           ISecurityService securityService,
                           IJwtService jwtService)
        {
            _userRepository = userRepository;
            _securityService = securityService;
            _jwtService = jwtService;
        }

        public async Task<User> GetUserByID(Guid UserID){
            var user = await _userRepository.GetUserByID(UserID);
            return user;
        }

        public async Task<AuthDTO> Authenticate(AuthParams authParams){
            AuthDTO result = new AuthDTO();
            User user = await _userRepository.GetUserByEmail(authParams.Email);
            //var verifyHash = _securityService.CreateHMACSHA512Hash(authParams.Password);
            bool isEqualHash = _securityService.VerifyHMACSHA512Hash(authParams.Password, user.AcessHash);
            user.AcessHash = "";
            user.Addresses.Select(x => x.User = null).ToList();

            string token = _jwtService.GenerateToken(user, 120); //Expiration in 2 Hours;

            result.User = user;
            result.Token = token;

            if (isEqualHash) return result;

            return null;
        }
    }
}