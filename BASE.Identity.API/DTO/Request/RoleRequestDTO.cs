namespace BASE.Identity.API.DTO.Request
{
    public class RoleRequestDTO
    {
        public string RoleName { get; set; } = null!;

        public string? RoleDescription { get; set; }
    }
}
