namespace BASE.Identity.Repository.Models
{
    public class Token
    {
        public string Accesstoken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
        public DateTime RefreshTokenExpireDate { get; set; }
    }
}
