using BASE.Identity.Repository.Models;
using BASE.Identity.Repository.Repositories;
using BASE.Identity.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BASE.Identity.Services.Services
{
    public class UserService(DataBaseContext dataBaseContext) : IUserService
    {
        private readonly DataBaseContext context = dataBaseContext;
        private readonly RoleService roleService = new RoleService(dataBaseContext);

        public async Task<User?> GetUserByUserNameAsync(string userName)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            if (user != null)
            {
                return user;
            }

            return null;
        }

        public async Task<List<User>?> GetUsersAsync()
        {
            var users = await context.Users.ToListAsync();

            if (users != null)
            {
                return users;
            }

            return null;
        }

        public async Task CreateUserAsync(User request)
        {
            var role = await roleService.GetRoleByRoleName("User");

            if (request != null)
            {
                request.UserID = Guid.NewGuid();
                request.RoleID = role != null ? role.RoleID : Guid.NewGuid();
                request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
                request.CreatedDate = DateTime.UtcNow;
                request.ModifiedDate = DateTime.UtcNow;

                context.Users.Add(request);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateUserPasswordAsync(User request)
        {
            if (request != null)
            {
                var user = await GetUserByUserNameAsync(request.UserName);

                if (user != null)
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
                    user.ModifiedDate = DateTime.UtcNow;
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task HardRemoveUserAsync(User request)
        {
            if (request != null)
            {
                var user = await GetUserByUserNameAsync(request.UserName);

                if (user != null)
                {
                    context.Users.Remove(user);
                    await context.SaveChangesAsync();
                }

            }
        }

    }
}
