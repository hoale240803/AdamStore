using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Catalog.Categories;

namespace Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryVm>> GetAllAsync(string languageId);

        Task<CategoryVm> GetByIdAsync(string languageId, int id);
    }
}