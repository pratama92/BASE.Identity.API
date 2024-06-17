namespace BASE.Identity.API.Model
{
    public class UserResponseDTO
    {
        public Guid UserID { get; set; }

        public string UserName { get; set; } = null!;

        public string UserEmail { get; set; } = null!;

    }
}
