using BASE.Identity.Repository.Model;

namespace BASE.Identity.Services.Interfaces
{
    public interface IUserService
    {
        public Task<List<User>?> GetUsers();
        public Task<User?> GetUserByUserName(string userName);
        public Task CreateUser(User request);
    }
}
