using BASE.Identity.Repository.Models;
using BASE.Identity.Repository.Repositories;
using BASE.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BASE.Identity.Services.Services
{
    public class LoginService : ILoginService
    {

        public async Task<User?> AuthenticateLogin(string userName, string password)
        {
            var userService = new UserService();
            var user = await userService.GetUserByUserName(userName);
            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return user;
                }
            }
            return null;
        }

        public async Task<bool> DBConnectionTest()
        {
            DataBaseContext context = new DataBaseContext();
            if (await context.Database.CanConnectAsync())
            {
                return true;
            }
            return false;
        }
    }
}
