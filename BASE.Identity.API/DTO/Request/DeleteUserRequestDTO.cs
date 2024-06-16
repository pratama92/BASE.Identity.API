using System.ComponentModel.DataAnnotations;

namespace BASE.Identity.API.Model
{
    public record DeleteUserRequestDTO
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

    }
}
