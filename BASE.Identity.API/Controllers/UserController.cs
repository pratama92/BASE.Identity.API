using BASE.Identity.API.Model;
using BASE.Identity.Repository.Models;
using BASE.Identity.Services.Interfaces;
using BASE.Identity.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BASE.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController(IUserService _iuserService, IRoleService _roleService, ILogger<UserController> logger) : Controller
    {
        private readonly ILogger<UserController> _logger = logger;
        private readonly IUserService iuserService = _iuserService;
        private readonly IRoleService roleService = _roleService;

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetUsers()
        {
            _logger.LogInformation(">> Get All User <<");

            var users = await iuserService.GetUsersAsync();

            var result = new List<UserResponseDTO>();
            if (users != null)
            {
                foreach (var item in users)
                {
                    var role = await roleService.GetRoleByRoleID(item.RoleID);
                    result.Add(new UserResponseDTO() { UserID = item.UserID, UserName = item.UserName, UserEmail = item.Email, UserRole = role!= null ? role.RoleName : string.Empty  });
                }
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("username")]

        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            _logger.LogInformation(">> Get User: <<" + userName);

            var user = await iuserService.GetUserByUserNameAsync(userName);

            if (user != null)
            {
                var role = await roleService.GetRoleByRoleID(user.RoleID);
                var result = new UserResponseDTO()
                {
                    UserName = user.UserName,
                    UserEmail = user.Email,
                    UserID = user.UserID,
                    UserRole = role != null ? role.RoleName : string.Empty
                };

                return Ok(result);
            }

            return NotFound("User Is Not Exist!");

        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequestDTO request)
        {
            _logger.LogInformation(">> Create User: <<" + request.UserName);

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

            await iuserService.CreateUserAsync(user);

            return Ok();
        }

        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequestDTO request)
        {
            _logger.LogInformation(">> Change Password <<" + request.UserName);

            var user = new User();
            user.UserName = request.UserName;
          
            if (!await user.IsUserExist())
            {
                return NotFound("User Is Not Exist!");
            }

            if (request.NewPassword == request.CurrentPassword)
            {
                return BadRequest("The new password must not be the same with current password!");
            }

            user.Password = request.CurrentPassword;
            if (!await user.CheckCurrentPassword())
            {
                return BadRequest("The current password is not correct");
            }

            string message = string.Empty;
            user.Password = request.NewPassword;
            if (user.IsPasswordNotOkay(ref message))
            {
                return BadRequest(message);
            }
           
            await iuserService.UpdateUserPasswordAsync(user);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(DeleteUserRequestDTO request)
        {
            _logger.LogInformation(">> Delete User: <<" + request.UserName);


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

            await iuserService.HardRemoveUserAsync(user);

            return Ok();
        }
    }
}
