using BASE.Identity.Repository.Model;
using BASE.Identity.Repository.Repositories;
using BASE.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BASE.Identity.Services.Services
{
    public class LoginService : ILoginService
    {
        private DataBaseContext context = new DataBaseContext();

        public async Task< User?> ValidateLogin(string userName, string password)
        {          
            var user  = await context.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefaultAsync();

            if (user != null)
            {
                return user;
            }

            return null;
        
        }

        public async Task<bool> DBConnectionTest()
        {          
            if (await context.Database.CanConnectAsync())
            {
                return true;
            }
            return false;
        }
    }
}
