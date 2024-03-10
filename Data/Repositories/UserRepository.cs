using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalBudget.Model;
using System.Runtime.CompilerServices;

namespace PersonalBudget.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BudgetContext context;
        public UserRepository(BudgetContext _context)
        {
            context = _context;
        }

        public async Task<User> AuthenticateUser(string username, string password)
        {
            var users = await context.Users.ToListAsync();
            if (users.Any())
            {
                var user = from item in users
                           where item.Username == username
                           select item;
                PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
                var success = passwordHasher.VerifyHashedPassword(user.FirstOrDefault(), user.FirstOrDefault().Password, password);
                if (success == PasswordVerificationResult.Success)
                {
                    return user.FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task CreateUser(User user)
        {
            try
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteUser(User user)
        {
            try
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetUserDetails(int id)
        {
            var user = await context.Users.FindAsync(id);
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await context.Users.ToListAsync();
            return users;
        }

        public async Task UpdateUser(User user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }
    }
}
