using BASE.Identity.API.Model;
using BASE.Identity.Repository.Models;
using BASE.Identity.Services.Interfaces;
using BASE.Identity.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace BASE.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService _iuserService) : Controller
    {

        private readonly IUserService iuserService = _iuserService;

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await iuserService.GetUsers();

            var result = new List<UserResponseDTO>();
            if (users != null)
            {
                foreach(var item in users)
                {
                    result.Add(new UserResponseDTO() { UserID = item.UserID, UserName = item.UserName, UserEmail = item.Email});   
                }
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("username")]

        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var user = await iuserService.GetUserByUserName(userName);

            if (user != null)
            {
                var result = new UserResponseDTO()
                {
                    UserName = user.UserName,
                    UserEmail = user.Email,
                    UserID = user.UserID,
                };

                return Ok(result);
            }

            return NotFound("User Is Not Exist!");

        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequestDTO request)
        {
            var user = new User
            {
                UserName = request.UserName,
                Password = request.Password,
                Email = request.UserEmail
            };

            if (await user.IsUserExist())
            {
                return BadRequest("User Already Exist!");
            }

            string message = string.Empty;
            if (user.IsPasswordNotOkay(ref message))
            {
                return BadRequest(message);
            }

            await iuserService.CreateUser(user);

            return Ok();
        }

        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequestDTO request)
        {
            var user = new User
            {
                UserName = request.UserName,
                Password = request.NewPassword
            };

            if (!await user.IsUserExist())
            {
                return NotFound("User Is Not Exist!");
            }

            if (await user.CheckCurrentPassword())
            {
                return BadRequest("New password must not be the same with current password!");
            }

            string message = string.Empty;
            if (user.IsPasswordNotOkay(ref message))
            {
                return BadRequest(message);
            }

            await iuserService.UpdateUser(user);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(DeleteUserRequestDTO request)
        {
            var user = new User
            {
                UserName = request.UserName,
                Password = request.Password
            };

            if (!await user.IsUserExist())
            {
                return NotFound("User Is Not Exist!");
            }

            if (!await user.CheckCurrentPassword())
            {
                return BadRequest("The password is not correct");
            }

            await iuserService.HardRemoveUser(user);

            return Ok();
        }
    }
}
