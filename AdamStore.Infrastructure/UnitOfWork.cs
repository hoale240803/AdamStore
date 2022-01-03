using AdamStore.Infrastructure.EF;
using AdamStore.Infrastructure.Repositories;
using Application._Abstracts;
using Application.Auth;
using Application.Catalog.Products;
using Application.Users;
using System;
using System.Threading.Tasks;

namespace AdamStore.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private AdamStoreDbContext _dbContext;
        public IAuthRepository Auths { get; private set; }
        public IProductRepository Products { get; private set; }
        public IProductImageRepository ProductImages{ get; private set; }
        public IProductTranslationRepository ProductTranslations { get; private set; }
        public IProductInCategoryRepository ProductInCategories { get; private set; }

        public IUserRepository Users{ get; private set; }

        public UnitOfWork(AdamStoreDbContext dbContext)

        {
            _dbContext = dbContext;
            Users = new UserRepository(dbContext);
            Products = new ProductRepository(dbContext);
            ProductTranslations = new ProductTranslationRepository(dbContext);
            ProductImages = new ProductImageRepository(dbContext);
            ProductInCategories = new ProductInCategoryRepository(dbContext);
        }

        public async Task<bool> CommitAsync()
        {
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _dbContext.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}