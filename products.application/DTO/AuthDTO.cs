using products.core.Entities;

namespace Products.Application.DTO
{
    public class AuthDTO
    {
        public User? User {get;set;}
        public string? Token {get;set;}
    }
}