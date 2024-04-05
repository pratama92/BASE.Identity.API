using BASE.Identity.API.Model;
using BASE.Identity.Repository.Model;
using BASE.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BASE.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserService iuserService;

        public UserController(IUserService _iuserService)
        {
            iuserService = _iuserService;
        }

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
                    UserEmail = user.UserEmail,
                    IsActive = user.IsActive,
                    IsLocked = user.IsLocked,
                };

                return Ok(result);
            }

            return BadRequest();
           
        }

        [HttpPost]
        public async Task<IActionResult> PostUser (UserRequestDTO request)
        {
            var user = new User();
            user.UserName = request.UserName;
            user.Password = request.Password;
            user.UserEmail = request.UserEmail;

            await iuserService.CreateUser(user);

            return Ok();
        }
    }
}
