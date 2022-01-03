using Application.Catalog.Categories;
using Shared.Entities;

namespace AdamStore.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}