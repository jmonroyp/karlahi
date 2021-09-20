using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KarlaHi.Api.Dtos;
using KarlaHi.Api.Responses;
using KarlaHi.Core.Repositories;
using KarlaHi.Core.Specifications;
using KarlaHi.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KarlaHi.Api.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo,
        IGenericRepository<ProductType> productTypeRepo, IGenericRepository<ProductBrand> productBrandRepo, IMapper mapper)
        {
            _mapper = mapper;
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            return _mapper
            .Map<List<Product>, List<ProductDto>>(await _productRepo
            .GetAllWithSpecAsync(new ProductsWithTypesAndBrandsSpecification()));
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetProduct(int id)
        {
            return _mapper
            .Map<Product, ProductDto>(await _productRepo
            .GetWithSpecAsync(new ProductsWithTypesAndBrandsSpecification(id)));
        }

        [HttpGet("brands")]
        public async Task<IEnumerable<ProductBrand>> GetBrands()
        {
            return await _productBrandRepo.GetAllAsync();
        }

        [HttpGet("types")]
        public async Task<IEnumerable<ProductType>> GetTypes()
        {
            return await _productTypeRepo.GetAllAsync();
        }
    }
}