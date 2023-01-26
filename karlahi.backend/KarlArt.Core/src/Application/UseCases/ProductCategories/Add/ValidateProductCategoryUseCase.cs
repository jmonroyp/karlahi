using KarlArt.Core.Application.Common.Interfaces.Repositories;
using KarlArt.Core.Application.Common.Interfaces.UseCases.ProductCategories;

namespace KarlArt.Core.Application.UseCases.ProductCategories.Add;
public class ValidateProductCategoryUseCase : IValidateProductCategory
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ValidateProductCategoryUseCase(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }
    public Task<Result<ProductCategory>> ExecuteAsync(ProductCategory request) =>
        AsyncResult.WithAsync(() => _productCategoryRepository.GetBySearchCriteriaAsync(x => x.Name == request.Name))
            .BindAsync(productCategory => productCategory is not null
                ? Task.FromResult(Result<ProductCategory>.Failure(new[] { $"Product category with name {request.Name} already exists" }))
                : Task.FromResult(Result<ProductCategory>.Success(request)));


}