using System.Collections.Generic;
using System.Threading.Tasks;
using KarlaHi.Infrastructure.Entities;

namespace KarlaHi.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();       
    }
}