using BASE.Identity.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BASE.Identity.Services.Interfaces
{
    public interface IRoleService
    {
        public Task<Role?> GetRoleByRoleName(string roleName);
        public Task<Role?> GetRoleByRoleID(Guid roleID);
    }
}
