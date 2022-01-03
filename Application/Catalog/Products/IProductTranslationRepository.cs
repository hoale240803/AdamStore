using Application._Abstracts;
using Shared.Entities;
using System.Threading.Tasks;

namespace Application.Catalog.Products
{
    public interface IProductTranslationRepository : IRepository<ProductTranslation>
    {
        ProductTranslation GetProductTranslation(int productId, string languageId);
    }
}