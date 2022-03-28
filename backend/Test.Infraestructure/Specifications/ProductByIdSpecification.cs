using System;
using Test.Infraestructure.Entities;

namespace Test.Infraestructure.Specifications
{
     public class ProductByIdSpecification : Specification<Product>
    {
        public ProductByIdSpecification(int id) : base(x => x.Id == id)
        {
           
        }
    }
}