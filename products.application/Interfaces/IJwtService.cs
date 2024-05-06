namespace Products.Application.Interfaces
{
    public interface IJwtService
    {
        public string GenerateToken(object payload, int expirationMinutes);
    }
}