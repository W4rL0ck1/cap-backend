using products.application.DTO;
using products.application.Interfaces.Generic;
using products.core.Entities;
using products.infrastructure.Repositories;
using Products.Application.DTO;
using Products.Application.Interfaces;

namespace Products.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurityService _securityService;
        private readonly IJwtService _jwtService;
        private readonly IBaseResult _baseResult;
        public UserService(IUserRepository userRepository,
                           ISecurityService securityService,
                           IJwtService jwtService,
                           IBaseResult baseResult)
        {
            _userRepository = userRepository;
            _securityService = securityService;
            _jwtService = jwtService;
            _baseResult = baseResult;
        }

        public async Task<User> GetUserByID(Guid UserID){
            var user = await _userRepository.GetUserByID(UserID);
            return user;
        }

        public async Task<ResultDTO<AuthDTO>> Authenticate(AuthParamsDTO authParams){
            AuthDTO result = new AuthDTO();
            User user = await this.returnUser(authParams.Email);

            if (user == null) return _baseResult.returnResult(result, false, "Usuário não encontrado!");

            bool isEqualHash = _securityService.VerifyHMACSHA512Hash(authParams.Password, user.AcessHash);
            string token = _jwtService.GenerateToken(user, 120); //Expiration in 2 Hours;

            result.User = user;
            result.Token = token;

            if (isEqualHash) return _baseResult.returnResult(result, true, null);

            return _baseResult.returnResult(result, false, "Usuário ou Senha invalidos!");
        }
        public async Task<ResultDTO<User>> CreateUser(NewUserDTO prUser){
            var newUser = new User(prUser.UserName, prUser.Email, prUser.Gender, prUser.CPFCNPJ);
            var hash = _securityService.CreateHMACSHA512Hash(prUser.Password);
            newUser.AcessHash = hash;

            try
            {
                var wasUserCreated = await _userRepository.CreateUser(newUser);
                if(wasUserCreated){
                    var user = await _userRepository.GetUserByEmail(prUser.Email);
                    return _baseResult.returnResult(user, true, null);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);// Se implantado sistema de logs, salvar log no banco.
                _baseResult.returnResult(newUser, false, $"Ocorreu um erro ao tentar criar um usuário!: {ex}");
            }
            return _baseResult.returnResult(newUser, false, $"Usuário não foi criado com sucesso! Entre em contato com o Administrador!");
        }

        private async Task<User> returnUser(string prEmail){
            User user = await _userRepository.GetUserByEmail(prEmail);
            user.AcessHash = ""; // Removendo hash do usuário no retorno do token
            user.Addresses.Select(x => x.User = null).ToList(); // Removendo redudancia no endereço;
            return user;
        }
    }
}