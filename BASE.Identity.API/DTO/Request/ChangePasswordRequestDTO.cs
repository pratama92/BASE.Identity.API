using System.ComponentModel.DataAnnotations;

namespace BASE.Identity.API.Model
{
    public record ChangePasswordRequestDTO
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string CurrentPassword { get; set; } = null!;

        [Required]
        public string NewPassword { get; set; } = null!;

    }
}
