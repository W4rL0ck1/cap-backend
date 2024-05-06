using products.core.Entities;

namespace products.application.DTO
{
    public class NewUserDTO
    {
        public string Name {get;set;}
        public string Email {get;set;}
        public string Gender {get;set;}
        public string CPFCNPJ {get;set;}
        public string Password {get;set;}
        public List<Address>? Addresses {get;set;}
    }
}