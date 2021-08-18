using System.Collections.Generic;
using System.Threading.Tasks;
using KarlaHi.Infrastructure.Data;
using KarlaHi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace KarlaHi.Core.Repositories
{
    public class ProductsRepository : GenericRepository<Product>
    {
        public ProductsRepository(StoreContext storeContext) : base(storeContext)
        {
        }

        public override async Task<List<Product>> GetAllAsync()
        {
            return await _storeContext.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .ToListAsync();
        }
    }
}