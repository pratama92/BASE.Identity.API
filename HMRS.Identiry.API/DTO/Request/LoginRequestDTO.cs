namespace HMRS.Identity.API.DTO.Request
{
    public class LoginRequestDTO
    {
        public string UserName { get; set; } = null!;
        public string? Password { get; set; }
    }
}
