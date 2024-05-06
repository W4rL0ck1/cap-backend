using System.Collections.ObjectModel;
using products.core.Entities.Generic;

namespace products.core.Entities
{
    public class User: BaseModel
    {
        public User()
        {
            this.Addresses = new HashSet<Address>();
        }

        public User(string name, string email, string gender, string cpfCnpj)
        {
            Name = name;
            Email = email;
            Gender = gender;
            CPFCNPJ = cpfCnpj;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string CPFCNPJ { get; set; }
        public string AcessHash {get;set;}

        public HashSet<Address> Addresses {get;set;}
    }
}