namespace HMRS.Identity.API.DTO.Response
{
    public class LoginResponseDTO
    {
        public string UserName { get; set; } = null!;
        public string Status { get; set; } = null!;
        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
    }
}
