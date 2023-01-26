using KarlArt.Core.Application.Common.Interfaces.Repositories;
using KarlArt.Core.Application.Common.Interfaces.UseCases.ProductCategories;

namespace KarlArt.Core.Application.UseCases.ProductCategories.Add;
public class AddProductCategoryUseCase : IAddProductCategory
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IValidateProductCategory _validateProductCategory;

    public AddProductCategoryUseCase(IProductCategoryRepository productCategoryRepository, IValidateProductCategory validateProductCategory)
    {
        _productCategoryRepository = productCategoryRepository;
        _validateProductCategory = validateProductCategory;
    }

    public async Task<Result<ProductCategory>> ExecuteAsync(ProductCategory productCategory) =>
         Result<ProductCategory>.Success(await _productCategoryRepository.AddAsync(productCategory));
}
