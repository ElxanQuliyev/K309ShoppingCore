using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public int ID { get; set; }
            
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description{ get; set; }
        public string PictureUrl{ get; set; }
        public short Quantity { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public decimal Discount { get; set; }
    }
}
