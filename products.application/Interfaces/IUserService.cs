using products.core.Entities;
using Products.Application.DTO;

namespace Products.Application.Interfaces
{
    public interface IUserService
    {
        public  Task<User> GetUserByID(Guid UserID);
        public  Task<AuthDTO> Authenticate(AuthParams authParams);
    }
}