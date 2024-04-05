using System.ComponentModel.DataAnnotations;

namespace BASE.Identity.API.Model
{
    public class UserRequestDTO
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; } = null!;

    }
}
