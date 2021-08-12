using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarlaHi.Core.Services;
using KarlaHi.Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KarlaHi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _pService;
        public ProductsController(IProductsService pService) {
            _pService = pService;
        }

        [HttpGet]
        //[Authorize]
        public async Task<List<Product>> GetProducts()
        {
            return  await _pService.GetProductsAsync();
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            return await _pService.GetProductAsync(id);
        }

        [HttpGet("brands")]
        public async Task<List<ProductBrand>> GetBrands()
        {
            return await _pService.GetProductBrandsAsync();
        }

        [HttpGet("types")]
        public async Task<List<ProductType>> GetTypes()
        {
            return await _pService.GetProductTypesAsync();
        }
    }
}