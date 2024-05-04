using System.ComponentModel.DataAnnotations.Schema;

namespace products.core.Entities.Generic
{
    public class GenericModel
    {
        [Column("DT_UPDATED")]
        public DateTime UpdatedDate { get; set; }
        [Column("DT_CREATED")]
        public DateTime CreatedDate { get; set; }
        [Column("ID")]
        public Guid Id {get;set;}
    }
}