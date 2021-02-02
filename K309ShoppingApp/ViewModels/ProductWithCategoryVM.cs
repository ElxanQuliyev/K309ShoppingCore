using Entities;
using K309ShoppingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K309ShoppingApp.ViewModels
{
    public class ProductWithCategoryVM
    {
        public List<Category> Categories{ get; set; }
        public List<Product>Products { get; set; }
        public string searchTerm { get; set; }
        public int? CategoryID { get; set; }
        public int? SortBy { get; set; }
    }
}
