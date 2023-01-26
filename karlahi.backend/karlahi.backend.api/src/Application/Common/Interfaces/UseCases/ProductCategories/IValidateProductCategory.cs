using KarlArt.Core.Application.Common.Interfaces.UseCases.Common;

namespace KarlArt.Core.Application.Common.Interfaces.UseCases.ProductCategories;
public interface IValidateProductCategory : IUseCase<ProductCategory, Result<ProductCategory>>
{
}