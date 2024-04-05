using System.ComponentModel.DataAnnotations;

namespace BASE.Identity.Repository.Model
{
    public partial class User
    {
        [Key]
        public String UserId { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string UserEmail { get; set; } = null!;

        public byte  IsActive { get; set; }

        public byte IsLocked { get; set; }

    }
}
