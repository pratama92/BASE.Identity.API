using BASE.Identity.Repository.Models;
using BASE.Identity.Repository.Repositories;
using BASE.Identity.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BASE.Identity.Services.Services
{
    public class RoleService(DataBaseContext dataBaseContext) : IRoleService
    {
        private readonly DataBaseContext context = dataBaseContext;

        public async Task<List<Role>?> GetRoles()
        {
            var roles = await context.Roles.ToListAsync();

            if (roles != null)
            {
                return roles;
            }

            return null;
        }

        public async Task<Role?> GetRoleByRoleName(string roleName)
        {
            var role = await context.Roles.FirstOrDefaultAsync(x => x.RoleName == roleName.ToLower());

            if (role != null)
            {
                return role;
            }

            return null;
        }

        public async Task<Role?> GetRoleByRoleID(Guid roleID)
        {
            var role = await context.Roles.FirstOrDefaultAsync(x => x.RoleID == roleID);

            if (role != null)
            {
                return role;
            }

            return null;
        }

        public async Task CreateRole(Role role)
        {            
            role.RoleID = Guid.NewGuid();
            role.CreatedDate = DateTime.Now;
            role.ModifiedDate = DateTime.Now;   

            context.Roles.Add(role);
            await context.SaveChangesAsync();
        }
    }
}
