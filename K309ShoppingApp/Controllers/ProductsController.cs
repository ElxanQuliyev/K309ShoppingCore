using Data;
using K309ShoppingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helper;

namespace Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private ProductService _productService;
        private CategoryService _categoryService;
        public ProductsController(ILogger<ProductsController> logger, ApplicationDbContext applicationDbContext)
        {
            _productService = new ProductService(applicationDbContext);
            _logger = logger;
            _categoryService = new CategoryService(applicationDbContext);
        }

        public IActionResult Index(int? id, string searchTerm, int? sortby,int? pageNo,int? recordSize)
        {
            recordSize = recordSize.HasValue ? recordSize.Value:3;
            ProductWithCategoryVM vm = new()
            {
                Categories = _categoryService.GetCategories(),
                Products = _productService.SearchProductFilter(id, searchTerm, sortby,pageNo,recordSize.Value, out int count),
                searchTerm = searchTerm,
                CategoryID = id,
                SortBy = sortby,
                PageNo=pageNo,
                PageSize=recordSize.Value
            };
            vm.Pager = new Pager(count, pageNo, recordSize.Value);

            return View(vm);
        }

    }
}
