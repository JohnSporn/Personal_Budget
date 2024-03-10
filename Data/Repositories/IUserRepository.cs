using PersonalBudget.Model;

namespace PersonalBudget.Data.Repositories
{
    public interface IUserRepository
    {
        public Task CreateUser(User user);
        public Task UpdateUser(User user);
        public Task DeleteUser(User user);
        public Task<User> GetUserDetails(int id);
        public Task<List<User>> GetUsers();
        public Task<User> AuthenticateUser(string username, string password);
    }
}
