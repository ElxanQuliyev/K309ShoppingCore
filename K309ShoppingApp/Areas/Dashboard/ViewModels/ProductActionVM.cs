using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K309ShoppingApp.Areas.Dashboard.ViewModels
{
    public class ProductActionVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public short Quantity { get; set; }
        public int CategoryID { get; set; }
        public decimal Discount { get; set; }
        public IFormFile PictureUrl { get; set; }

    }
}
