using BASE.Identity.Repository.Models;

namespace BASE.Identity.Services.Interfaces
{
    public interface ILoginService
    {
        public Task<User?> AuthenticateLogin(string userName, string password);
        public Task<bool> DBConnectionTest();
    }
}
