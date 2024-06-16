using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BASE.Identity.Repository.Models
{
    [Table("TblUser")]
    public class User
    {
        [Key]
        public Guid UserID { get; set; }

        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        public Guid RoleID { get; set; } 

        //public byte  IsActive { get; set; }

        //public byte IsLocked { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

    }
}
