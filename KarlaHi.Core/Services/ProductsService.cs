using System.Collections.Generic;
using System.Threading.Tasks;
using KarlaHi.Infrastructure.Data;
using KarlaHi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace KarlaHi.Core.Services
{
    public class ProductsService : IProductsService
    {
        private readonly StoreContext _context;
        public ProductsService(StoreContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProduct(int id)
        {
           return await _context.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetProductsList()
        {
            return  await _context.Products.ToListAsync();
        }
    }
}