namespace BASE.Identity.API.Model
{
    public class UserResponseDTO
    {
        public string UserName { get; set; } = null!;

        public string UserEmail { get; set; } = null!;

        public byte IsActive { get; set; }

        public byte IsLocked { get; set; }

    }
}
