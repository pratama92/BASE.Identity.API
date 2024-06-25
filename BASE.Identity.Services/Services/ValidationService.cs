using BASE.Identity.Repository.Models;
using BASE.Identity.Repository.Repositories;
using System.Text.RegularExpressions;

namespace BASE.Identity.Services.Services
{
    public static class ValidationService
    {
        private static UserService userService =  new UserService(new DataBaseContext());

        public static async Task<bool> IsUserExist(this User user)
        {
            
            var username = await userService.GetUserByUserNameAsync(user.UserName);

            if (username != null)
            {
                return true;
            }

            return false;
        }

        public static async Task<bool> CheckCurrentPassword(this User user)
        {
            //UserService userService = new UserService();
            var username = await userService.GetUserByUserNameAsync(user.UserName);

            if (username != null)
            {
                if (BCrypt.Net.BCrypt.Verify(user.Password, username.Password))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsPasswordNotOkay(this User user, ref string message)
        {
            var password = user.Password;

            if (password.Length < 7 || password.Length > 31)
            {
                message = "The password length must be between 8 - 30 character!";
                return true;
            }

            if (password.ToLower().Contains("password"))
            {
                message = "The password must not contain word password!";
                return true;
            }

            if (!Regex.IsMatch(password, @"\d"))
            {
                message = "The password must contain a number";
                return true;
            }

            if (!Regex.IsMatch(password, @"[\p{P}\p{S}]"))
            {
                message = "The password must have a unique character";
                return true;
            }

            if (!password.Any(char.IsUpper))
            {
                message = "The password must have a capital!";
                return true;
            }

            return false;

        }


    }
}
