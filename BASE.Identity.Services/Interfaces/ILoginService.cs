using BASE.Identity.Repository.Model;

namespace BASE.Identity.Services.Interfaces
{
    public interface ILoginService
    {
        public Task<User?> ValidateLogin(string userName, string password);
        public Task<bool> DBConnectionTest();
    }
}
