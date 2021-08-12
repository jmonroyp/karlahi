using System.Collections.Generic;
using System.Threading.Tasks;
using KarlaHi.Infrastructure.Entities;

namespace KarlaHi.Core.Services
{
    public interface IProductsService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int id);
        Task<List<ProductType>> GetProductTypesAsync();
        Task<List<ProductBrand>> GetProductBrandsAsync();
    }
}