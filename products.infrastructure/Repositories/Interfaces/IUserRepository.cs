using products.core.Entities;

namespace products.infrastructure.Repositories
{
    public interface IUserRepository
    {  
        public Task<User> GetUserByID(Guid prUserId);
        public Task<bool> CreateUser(User prUser);
        public Task<bool> DeleteUserByID(Guid prUserId);
        public Task<bool> UpdateUser(User prUser);
        public Task<List<User>> GetAllUsers();
    }
}