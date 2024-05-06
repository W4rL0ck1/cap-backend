using products.core.Entities.Generic;

namespace products.core.Entities
{
    public class Address: BaseModel
    {
        public Address(){
            this.User = new User();
        }
        public Guid UserID { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CEP {get;set;}
        public bool Active {get;set;}

        public virtual User User {get;set;}
    }
}