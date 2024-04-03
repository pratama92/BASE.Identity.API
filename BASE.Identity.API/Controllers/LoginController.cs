using HMRS.Identity.Services.Interfaces;
using HMRS.Identity.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

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

        [HttpGet]
        public ActionResult GetLogin()
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
