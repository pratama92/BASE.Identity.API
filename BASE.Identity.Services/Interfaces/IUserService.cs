using BASE.Identity.Repository.Models;

namespace BASE.Identity.Services.Interfaces
{
    public interface IUserService
    {
        public Task<List<User>?> GetUsers();
        public Task<User?> GetUserByUserName(string userName);
        public Task CreateUser(User request);
        public Task UpdateUser(User request);
        public Task HardRemoveUser(User request);

    }
}
