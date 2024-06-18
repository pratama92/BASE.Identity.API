using BASE.Identity.Repository.Models;
using BASE.Identity.Repository.Repositories;
using BASE.Identity.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BASE.Identity.Services.Services
{
    public class LoginService : ILoginService
    {
        private static UserService userService = new UserService(new DataBaseContext());

        public async Task<User?> AuthenticateLogin(string userName, string password)
        {

            var user = await userService.GetUserByUserName(userName);
            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return user;
                }
            }
            return null;
        }

        public string GenerateAccessToken(User user)
        {
            SymmetricSecurityKey securityKey;
            SigningCredentials credentials;

            var appSetting = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            if (appSetting != null)
            {
                var key = appSetting.GetValue<string>("JWT:key");
                var issuer = appSetting.GetValue<string>("Jwt:Issuer");
                var audience = appSetting.GetValue<string>("Jwt:Audience");

                if (key != null)
                {
                    securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                    credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    if (user != null)
                    {
                        if (user.UserName != null)
                        {
                            var token = new JwtSecurityToken(issuer, audience,
                           claims: new List<Claim>
                           {
                               new("userName", user.UserName ),
                           },
                           expires: DateTime.Now.AddMinutes(60),
                           signingCredentials: credentials);

                            return new JwtSecurityTokenHandler().WriteToken(token);
                        }
                       
                    }
                }
            }

            return string.Empty;
        }

        public async Task<bool> DBConnectionTest()
        {
            DataBaseContext context = new DataBaseContext();
            if (await context.Database.CanConnectAsync())
            {
                return true;
            }
            return false;
        }
    }
}
