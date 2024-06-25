using BASE.Identity.Repository.Models;

namespace BASE.Identity.Services.Interfaces
{
    public interface IUserService
    {
        public Task<List<User>?> GetUsersAsync();
        public Task<User?> GetUserByUserNameAsync(string userName);
        public Task CreateUserAsync(User request);
        public Task UpdateUserPasswordAsync(User request);
        public Task HardRemoveUserAsync(User request);

    }
}
