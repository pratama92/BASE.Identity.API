using BASE.Identity.API.DTO.Request;
using BASE.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc

namespace HMRS.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginService _loginService;

        public LoginController(ILogger<LoginController> logger, ILoginService loginService)
        {
            _logger = logger;
            _loginService = loginService;
        }

        [HttpPost]
        public ActionResult PostLogin(LoginRequestDTO request)
        {
            _logger.LogInformation(">> Post user by username and password <<");

            var result = _loginService.ValidateLogin();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}
