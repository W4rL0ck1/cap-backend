using products.core.Entities;

namespace products.infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {  
        public User GetUserByID(Guid prUserId);
        public bool CreateUser(User prUser);
        public bool DeleteUserByID(Guid prUserId);
        public bool UpdateUser(User prUser);
        public List<User> GetAllUsers();
    }
}