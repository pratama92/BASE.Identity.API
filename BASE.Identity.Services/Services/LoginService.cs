using BASE.Identity.Repository.Models;
using BASE.Identity.Repository.Repositories;
using BASE.Identity.Services.Interfaces;

namespace BASE.Identity.Services.Services
{
    public class LoginService : ILoginService
    {
        private static UserService userService = new UserService(new DataBaseContext());

        public async Task<User?> AuthenticateLogin(string userName, string password)
        {

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
