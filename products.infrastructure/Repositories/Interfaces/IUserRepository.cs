using products.core.Entities;

namespace products.infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {  
        public User GetUserByID(Guid prUserId);
        public bool DeleteUserByID(Guid prUserId);
        public List<User> GetAllUsers();
    }
}