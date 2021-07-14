using System.Collections.Generic;
using System.Threading.Tasks;
using KarlaHi.Infrastructure.Entities;

namespace KarlaHi.Core.Services
{
    public interface IProductsService
    {
        Task<List<Product>> GetProductsList();
        Task<Product> GetProduct(int id);
    }
}