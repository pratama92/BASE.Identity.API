using BASE.Identity.API.DTO.Request;
using BASE.Identity.API.DTO.Response;
using BASE.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HMRS.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(ILogger<LoginController> logger, ILoginService loginService) : ControllerBase
    {
        private readonly ILogger<LoginController> _logger = logger;
        private readonly ILoginService _loginService = loginService;

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    _logger.LogInformation(">> Test Connection <<");

        //    var result = await _loginService.DBConnectionTest();

        //    if (result)
        //    {
        //        return Ok("Connected");
        //    }

        //    return BadRequest("No Connection");
        //}

        [HttpPost]
        public async Task<ActionResult<LoginResponseDTO>> PostLogin(LoginRequestDTO request)
        {
            _logger.LogInformation(">> Login User <<" + request.UserName);

            var user = await _loginService.AuthenticateLogin(request.UserName, request.Password);

            if (user != null)
            {
                return Ok("Login Success!");
            }

            return BadRequest("Incorrect UserName or Password!");
        }

    }
}
