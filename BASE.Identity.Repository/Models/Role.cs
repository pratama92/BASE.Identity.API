using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BASE.Identity.Repository.Models
{
    [Table("TblRole")]
    public class Role
    {
        [Key]
        public Guid RoleID { get; set; }

        [Required]
        [MaxLength(100)]
        public string RoleName { get; set; } = null!;

        public string? RoleDescription { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    }

}

