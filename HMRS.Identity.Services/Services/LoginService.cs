using HMRS.Identity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMRS.Identity.Services.Services
{
    public class LoginService : ILoginService
    {
        public string ValidateLogin() {

            var result = "it is service";
            return result;
        
        }
    }
}
