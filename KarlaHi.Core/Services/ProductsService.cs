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

        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products
            .Include(p => p.ProductType)
             .Include(p => p.ProductBrand)
            .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .ToListAsync();
        }

        public async Task<List<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}