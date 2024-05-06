using products.core.Entities.Generic;

namespace products.core.Entities
{
    public class Checkout: BaseModel
    {
        public Checkout(){
            this.Products = new HashSet<Product>();
            this.User = new User();
        }
        public Guid UserId { get; set; }
        public int Discount { get; set; }
        public decimal ShippingCost { get; set; }

        public virtual HashSet<Product> Products {get;set;}
        public virtual User User {get;set;}
    }
}