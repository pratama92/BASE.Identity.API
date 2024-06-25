using BASE.Identity.Repository.Models;

namespace BASE.Identity.Services.Interfaces
{
    public interface ILoginService
    {
        public Task<bool> DBConnectionTest();
        public Task<Token?> GenerateToken(User user);
    }
}
