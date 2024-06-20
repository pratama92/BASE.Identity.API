using BASE.Identity.API.DTO.Request;
using BASE.Identity.Repository.Models;
using BASE.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BASE.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(IRoleService roleService) : Controller
    {
        private readonly IRoleService _roleService = roleService;

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {

            var roles = await _roleService.GetRoles();

            if (roles != null)
            {
                return Ok(roles);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleRequestDTO request)
        {
            var role = new Role()
            {
                RoleName = request.RoleName,
                RoleDescription = request.RoleDescription,
            };

            await _roleService.CreateRole(role);

            return Ok();
        }
    }
}
