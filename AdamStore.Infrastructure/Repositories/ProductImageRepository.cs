using AdamStore.Infrastructure.EF;
using Application._Abstracts;
using Application.Catalog.Products;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ViewModels.Catalog.Products;

namespace AdamStore.Infrastructure.Repositories
{
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        private AdamStoreDbContext _dbContext;

        private IUnitOfWork _unitOfWork;

        public ProductImageRepository(AdamStoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(ProductImage entity)
        {
            throw new NotImplementedException();
        }

        public void AddMulti(List<ProductImage> entity)
        {
            throw new NotImplementedException();
        }

        public bool CheckContains(Expression<Func<ProductImage, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<ProductImage, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductImage entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteMulti(Expression<Func<ProductImage, bool>> expression, IEnumerable<ProductImage> listT)
        {
            throw new NotImplementedException();
        }

        public ProductImage GetDefaultProductImage(int productId)
        {
            return _dbContext.ProductImages.FirstOrDefault(x => x.Id == productId && x.IsDefault);
        }

        public Task<List<ProductImage>> GetImagesAsync(int productId)
        {
            return _dbContext.ProductImages.Where(x => x.ProductId == productId)
              .Select(i => new ProductImage()
              {
                  Caption = i.Caption,
                  DateCreated = i.DateCreated,
                  FileSize = i.FileSize,
                  Id = i.Id,
                  ImagePath = i.ImagePath,
                  IsDefault = i.IsDefault,
                  ProductId = i.ProductId,
                  SortOrder = i.SortOrder
              }).ToListAsync();
        }

        public IQueryable<ProductImage> GetMultiPaging(Expression<Func<ProductImage, bool>> expression, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<ProductImage> GetSingleByCondition(Expression<Func<ProductImage, bool>> expression, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public ProductImage GetSingleById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductImage> List(Expression<Func<ProductImage, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductImage entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateMultiByIds(IEnumerable<ProductImage> listT)
        {
            throw new NotImplementedException();
        }
    }
}