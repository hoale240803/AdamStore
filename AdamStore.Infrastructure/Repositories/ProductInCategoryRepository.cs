using AdamStore.Infrastructure.EF;
using Application.Catalog.Products;
using Shared.Entities;

namespace AdamStore.Infrastructure.Repositories
{
    public class ProductInCategoryRepository : Repository<ProductInCategory>, IProductInCategoryRepository
    {
        private readonly AdamStoreDbContext _dbContext;

        public ProductInCategoryRepository(AdamStoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}