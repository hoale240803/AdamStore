using AdamStore.Infrastructure.EF;
using Application.Catalog.Products;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdamStore.Infrastructure.Repositories
{
    public class ProductTranslationRepository : Repository<ProductTranslation>, IProductTranslationRepository
    {
        private AdamStoreDbContext _dbContext;
        public ProductTranslationRepository(AdamStoreDbContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(ProductTranslation entity)
        {
            throw new NotImplementedException();
        }

        public void AddMulti(List<ProductTranslation> entity)
        {
            throw new NotImplementedException();
        }

        public bool CheckContains(Expression<Func<ProductTranslation, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<ProductTranslation, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductTranslation entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteMulti(Expression<Func<ProductTranslation, bool>> expression, IEnumerable<ProductTranslation> listT)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductTranslation> GetMultiPaging(Expression<Func<ProductTranslation, bool>> expression, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public ProductTranslation GetProductTranslation(int productId, string languageId )
        {
            return _dbContext.ProductTranslations.FirstOrDefault(x => x.Id == productId && x.LanguageId == languageId);
        }

        public Task<ProductTranslation> GetSingleByCondition(Expression<Func<ProductTranslation, bool>> expression, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public ProductTranslation GetSingleById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductTranslation> List(Expression<Func<ProductTranslation, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductTranslation entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateMultiByIds(IEnumerable<ProductTranslation> listT)
        {
            throw new NotImplementedException();
        }
    }
}