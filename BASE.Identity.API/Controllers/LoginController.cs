using BASE.Identity.API.DTO.Request;
using BASE.Identity.API.DTO.Response;
using BASE.Identity.Repository.Models;
using BASE.Identity.Services.Interfaces;
using BASE.Identity.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace HMRS.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(ILogger<LoginController> logger, ILoginService loginService) : ControllerBase
    {
        private readonly ILogger<LoginController> _logger = logger;
        private readonly ILoginService _loginService = loginService;

        [HttpPost]
        public async Task<ActionResult<LoginResponseDTO>> PostLogin(LoginRequestDTO request)
        {
            _logger.LogInformation(">> Login User <<" + request.UserName);

            var user = new User
            {
                UserName = request.UserName,
                Password = request.Password
            };

            if (await user.CheckCurrentPassword())
            {
                var token = await _loginService.GenerateToken(user);

                if (token != null)
                {
                    var tokenresponse = new LoginResponseDTO()
                    {
                        Token = token.Accesstoken,
                        RefreshToken = token.RefreshToken
                    };
                    return Ok(token);
                }
                else
                {
                    return BadRequest("Invalid Attempt!");
                }

            }

            return BadRequest("Incorrect UserName or Password!");
        }

    }
}
