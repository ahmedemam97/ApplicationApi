namespace Domain.Helper
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string https { get; set; }
        public string Audience { get; set; }
        public string JwtExpireDays { get; set; }
        public string JwtExpireMinutes { get; set; }
    }
}
