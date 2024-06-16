using BASE.Identity.API.Model;
using BASE.Identity.Repository.Models;
using BASE.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BASE.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService _iuserService) : Controller
    {

        private readonly IUserService iuserService = _iuserService;

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await iuserService.GetUsers();

            return Ok(users);
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
                };

                return Ok(result);
            }

            return BadRequest();

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

            await iuserService.CreateUser(user);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(ChangePasswordRequestDTO request)
        {
            var user = new User
            {
                UserName = request.UserName,
                Password = request.NewPassword
            };

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

            await iuserService.HardRemoveUser(user);

            return Ok();
        }
    }
}
