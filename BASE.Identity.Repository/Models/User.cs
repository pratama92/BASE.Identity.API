using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BASE.Identity.Repository.Model
{
    public partial class User
    {
        public String UserId { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string UserEmail { get; set; } = null!;

        public byte  IsActive { get; set; }

        public byte IsLocked { get; set; }

    }
}
