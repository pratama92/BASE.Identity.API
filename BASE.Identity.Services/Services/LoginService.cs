using BASE.Identity.Repository.Repositories;
using BASE.Identity.Services.Interfaces;

namespace BASE.Identity.Services.Services
{
    public class LoginService : ILoginService
    {
        public string ValidateLogin()
        {  

            var context = new DataBaseContext();
            string result = string.Empty;

            if (context.Database.CanConnect())
            {
                // all good
                result = "connected";
            }
            else
            {
                result = "not connect";
            }
            //var studentsWithSameName = context.Users.ToList();

            var getUsers = context.Users.FirstOrDefault();

            
            return result;
        
        }
    }
}
