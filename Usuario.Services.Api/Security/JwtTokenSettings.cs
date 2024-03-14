namespace Usuario.Services.Api.Security
{
    public class JwtTokenSettings
    {
        public string? SecretKey { get; set; }
        public int ExpirationInHour { get; set; }
    }
}
