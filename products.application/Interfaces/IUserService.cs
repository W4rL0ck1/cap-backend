using products.application.DTO;
using products.core.Entities;
using Products.Application.DTO;

namespace Products.Application.Interfaces
{
    public interface IUserService
    {
        public  Task<User> GetUserByID(Guid UserID);
        public  Task<ResultDTO<AuthDTO>> Authenticate(AuthParamsDTO authParams);
        public  Task<ResultDTO<User>> CreateUser(NewUserDTO prUser);
    }
}