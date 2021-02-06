using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService
    {
        public ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> SearchProductFilter(int? id, string searchTerm, int? sortby,int? pageNo,int? recordSize,out int count)
        {
            var proList = _context.Products.AsQueryable();

            if (id.HasValue)
            {
                proList = proList.Where(x => x.CategoryID == id);
            }
            if (!string.IsNullOrEmpty(searchTerm))
            {
                proList = proList.Where(p => p.Name.Contains(searchTerm));
            }
            if (sortby.HasValue)
            {
                switch (sortby)
                {
                    case 1:
                        proList = proList.OrderBy(x => x.Price);
                        break;
                    case 2:
                        proList = proList.OrderByDescending(x => x.Price);
                        break;
                    default:
                        proList = proList.OrderByDescending(x => x.ID);
                        break;
                }
            }
            pageNo = pageNo ?? 1;
            var skipCount = (pageNo.Value - 1) * recordSize.Value;
            count = proList.Count();

            return proList.Skip(skipCount).Take(recordSize.Value).ToList();

        }

        public async Task<bool> AddProduct(Product product)
        {
            _context.Products.Add(product);
           return await _context.SaveChangesAsync()>0;
        }

    }
}
