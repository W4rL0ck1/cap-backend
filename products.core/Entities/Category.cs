using products.core.Entities.Generic;

namespace products.core.Entities
{
    public class Category: GenericModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Discount { get; set; }
    }
}