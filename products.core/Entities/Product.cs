using products.core.Entities.Generic;

namespace products.core.Entities
{
    public class Product: GenericModel
    {
        public Guid CategoryID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public int Discount {get;set;}

        public virtual HashSet<Checkout> Checkout {get;set;}
        public virtual Category Category {get;set;}
    }
}