using products.core.Entities.Generic;

namespace products.core.Entities
{
    public class User: GenericModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string CPFCNPJ { get; set; }
        public string AcessHash {get;set;}
    }
}