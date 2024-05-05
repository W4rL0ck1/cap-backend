using System.Collections.ObjectModel;
using products.core.Entities.Generic;

namespace products.core.Entities
{
    public class User: GenericModel
    {
        public User()
        {
            this.Addresses = new HashSet<Address>();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string CPFCNPJ { get; set; }
        public string AcessHash {get;set;}

        public HashSet<Address> Addresses {get;set;}
    }
}