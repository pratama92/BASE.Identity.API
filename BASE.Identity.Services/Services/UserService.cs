using BASE.Identity.Repository.Models;
using BASE.Identity.Repository.Repositories;
using BASE.Identity.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace BASE.Identity.Services.Services
{
    public class UserService : IUserService
    {
        private readonly DataBaseContext context = new();

        public async Task<User?> GetUserByUserName(string userName)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            if (user != null)
            {
                return user;
            }

            return null;
        }

        public async Task<List<User>?> GetUsers()
        {
            var users = await context.Users.ToListAsync();

            if (users != null)
            {
                return users;
            }

            return null;
        }

        public async Task CreateUser(User request)
        {
            if (request != null)
            {
                request.UserID = Guid.NewGuid();
                request.RoleID = Guid.Parse("357CBB2B-6D02-4F09-AE66-95629DACEAE9");
                request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
                request.CreatedDate = DateTime.UtcNow;
                request.ModifiedDate = DateTime.UtcNow;

                context.Users.Add(request);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateUser(User request)
        {
            if (request != null)
            {
                var user = await GetUserByUserName(request.UserName);

                if (user != null)
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
                    user.ModifiedDate = DateTime.UtcNow;
                    await context.SaveChangesAsync();
                }

            }
        }

        public async Task HardRemoveUser(User request)
        {
            if (request != null)
            {
                var user = await GetUserByUserName(request.UserName);

                if (user != null)
                {
                    context.Users.Remove(user);
                    await context.SaveChangesAsync();
                }

            }
        }

    }
}
