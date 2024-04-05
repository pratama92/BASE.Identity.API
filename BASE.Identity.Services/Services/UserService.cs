using BASE.Identity.Repository.Model;
using BASE.Identity.Repository.Repositories;
using BASE.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BASE.Identity.Services.Services
{
    public class UserService : IUserService
    {
        private DataBaseContext context = new DataBaseContext();

        public async Task<User?> GetUserByUserName(string userName)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            if ( user != null)
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
                request.UserId = Guid.NewGuid().ToString();
                request.IsLocked = 0;
                request.IsActive = 1;

                context.Users.Add(request);
                await context.SaveChangesAsync();
            }             
        }

    }
}
