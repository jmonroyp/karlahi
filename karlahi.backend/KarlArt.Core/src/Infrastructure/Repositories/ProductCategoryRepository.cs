namespace KarlArt.Core.Infrastructure.Repositories;
public class ProductCategoryRepository : MongoRepository<ProductCategory>, IProductCategoryRepository
{
    public ProductCategoryRepository(IMongoDatabase database) : base(database)
    {
    }  
}
