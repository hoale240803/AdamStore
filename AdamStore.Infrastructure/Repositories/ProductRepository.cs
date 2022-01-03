using AdamStore.Infrastructure.EF;
using Application._Abstracts;
using Application.Catalog.Products;
using Application.Ultilities;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Catalog.ProductImages;
using ViewModels.Catalog.Products;
using ViewModels.Common;

namespace AdamStore.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AdamStoreDbContext _dbContext;
        private IUnitOfWork _unitOfWork;

        public ProductRepository(AdamStoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddViewcountAsync(int productId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ApiResult<bool>> CategoryAssignAsync(int id, CategoryAssignRequest request)
        {
            var user = await _dbContext.Products.FindAsync(id) 
                ?? throw new AppException();

            foreach (var category in request.Categories)
            {
                var productInCategory = await _dbContext.ProductInCategories
                    .FirstOrDefaultAsync(x => x.CategoryId == int.Parse(category.Id)
                    && x.ProductId == id);
                if (productInCategory != null && !category.Selected)
                {
                    _dbContext.ProductInCategories.Remove(productInCategory);
                }
                else if (productInCategory == null && category.Selected)
                {
                    await _dbContext.ProductInCategories.AddAsync(new ProductInCategory()
                    {
                        CategoryId = int.Parse(category.Id),
                        ProductId = id
                    });
                }
            }
            await _unitOfWork.CommitAsync();
            return new ApiResult<bool>();
        }

        public Task<bool> DeleteAsync(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<PagedResult<ProductVm>> GetAllByCategoryIdAsync(string languageId, GetPublicProductPagingRequest request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PagedResult<ProductVm>> GetAllPagingAsync(GetManageProductPagingRequest request)
        {
            //1. Select join
            var query = from p in _dbContext.Products
                        join pt in _dbContext.ProductTranslations on p.Id equals pt.ProductId
                        //join pic in _dbContext.ProductInCategories on p.Id equals pic.ProductId
                        //from pic in ppic.DefaultIfEmpty()
                        //join c in _dbContext.Categories on pic.CategoryId equals c.Id into picc
                        //from c in picc.DefaultIfEmpty()
                        //join pi in _dbContext.ProductImages on p.Id equals pi.ProductId into ppi
                        //from pi in ppi.DefaultIfEmpty()
                        //where pt.LanguageId == request.LanguageId && pi.IsDefault
                        select new { p, pt };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));

            //if (request.CategoryId != null && request.CategoryId != 0)
            //{
            //    query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            //}

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductVm()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    //ThumbnailImage = x.pi.ImagePath
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ProductVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<ProductVm> GetByIdAsync(int productId, string languageId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            var productTranslation = await _dbContext.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == productId
            && x.LanguageId == languageId);

            var categories = await(from c in _dbContext.Categories
                                   join ct in _dbContext.CategoryTranslations on c.Id equals ct.CategoryId
                                   join pic in _dbContext.ProductInCategories on c.Id equals pic.CategoryId
                                   where pic.ProductId == productId && ct.LanguageId == languageId
                                   select ct.Name).ToListAsync();

            var image = await _dbContext.ProductImages.Where(x => x.ProductId == productId && x.IsDefault).FirstOrDefaultAsync();

            var productViewModel = new ProductVm()
            {
                Id = product.Id,
                DateCreated = product.DateCreated,
                Description = productTranslation != null ? productTranslation.Description : null,
                LanguageId = productTranslation?.LanguageId,
                Details = productTranslation != null ? productTranslation.Details : null,
                Name = productTranslation != null ? productTranslation.Name : null,
                OriginalPrice = product.OriginalPrice,
                Price = product.Price,
                SeoAlias = productTranslation != null ? productTranslation.SeoAlias : null,
                SeoDescription = productTranslation != null ? productTranslation.SeoDescription : null,
                SeoTitle = productTranslation != null ? productTranslation.SeoTitle : null,
                Stock = product.Stock,
                ViewCount = product.ViewCount,
                Categories = categories,
                ThumbnailImage = image != null ? image.ImagePath : "no-image.jpg"
            };

            return productViewModel;
        }

        public async Task<List<ProductVm>> GetFeaturedProductsAsync(string languageId, int take)
        {
            //1. Select join
            var query = from p in _dbContext.Products
                        join pt in _dbContext.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _dbContext.ProductInCategories on p.Id equals pic.ProductId into ppic
                        from pic in ppic.DefaultIfEmpty()
                        join pi in _dbContext.ProductImages on p.Id equals pi.ProductId into ppi
                        from pi in ppi.DefaultIfEmpty()
                        join c in _dbContext.Categories on pic.CategoryId equals c.Id into picc
                        from c in picc.DefaultIfEmpty()
                        where pt.LanguageId == languageId && (pi == null || pi.IsDefault)
                        && p.IsFeatured == true
                        select new { p, pt, pic, pi };

            var data = await query.OrderByDescending(x => x.p.DateCreated).Take(take)
                .Select(x => new ProductVm()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    ThumbnailImage = x.pi.ImagePath
                }).ToListAsync();

            return data;
        }

        public Task<ProductImageViewModel> GetImageByIdAsync(int imageId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ProductVm>> GetLatestProductsAsync(string languageId, int take)
        {
            //1. Select join
            var query = from p in _dbContext.Products
                        join pt in _dbContext.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _dbContext.ProductInCategories on p.Id equals pic.ProductId into ppic
                        from pic in ppic.DefaultIfEmpty()
                        join pi in _dbContext.ProductImages on p.Id equals pi.ProductId into ppi
                        from pi in ppi.DefaultIfEmpty()
                        join c in _dbContext.Categories on pic.CategoryId equals c.Id into picc
                        from c in picc.DefaultIfEmpty()
                        where pt.LanguageId == languageId && (pi == null || pi.IsDefault)
                        select new { p, pt, pic, pi };

            var data = await query.OrderByDescending(x => x.p.DateCreated).Take(take)
                .Select(x => new ProductVm()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    ThumbnailImage = x.pi.ImagePath
                }).ToListAsync();

            return data;
        }

        public Task<List<ProductImageViewModel>> GetListImagesAsync(int productId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Product> GetSingleById(int productId, string languageId)
        {
            var product = await _dbContext.Products.FindAsync(productId);

            var productTranslation = await _dbContext.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == productId && x.LanguageId == languageId);

            var categories = await (from c in _dbContext.Categories
                                    join ct in _dbContext.CategoryTranslations on c.Id equals ct.CategoryId
                                    join pic in _dbContext.ProductInCategories on c.Id equals pic.CategoryId
                                    where pic.ProductId == productId && ct.LanguageId == languageId
                                    select ct.Name).ToListAsync();

            var image = await _dbContext.ProductImages.Where(x => x.ProductId == productId && x.IsDefault).FirstOrDefaultAsync();

            return product;
        }

        public Task<Product> GetSingleById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveImageAsync(int imageId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(Product request)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateImageAsync(int imageId, ProductImageUpdateRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdatePriceAsync(int productId, decimal newPrice)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateStockAsync(int productId, int addedQuantity)
        {
            throw new System.NotImplementedException();
        }

        Task<Product> IProductRepository.GetByIdAsync(int productId, string languageId)
        {
            throw new System.NotImplementedException();
        }
    }
}