﻿using System.ComponentModel.DataAnnotations;

namespace BASE.Identity.API.DTO.Request
{
    public class LoginRequestDTO
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
