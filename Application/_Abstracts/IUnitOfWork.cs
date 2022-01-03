using Application.Auth;
using Application.Catalog.Products;
using Application.Users;
using System.Threading.Tasks;

namespace Application._Abstracts
{
    public interface IUnitOfWork
    {

        IAuthRepository Auths { get; }
        IUserRepository Users { get; }
        IProductRepository Products { get; }
        IProductImageRepository ProductImages { get; }
        IProductTranslationRepository ProductTranslations { get; }
        IProductInCategoryRepository ProductInCategories { get; }
        Task<bool> CommitAsync();
    }
}