using Application._Abstracts;
using Application.Common;
using Application.Ultilities;
using Application.Ultilities.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Shared.Entities;
using Shared.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ViewModels.Catalog.ProductImages;
using ViewModels.Catalog.Products;
using ViewModels.Common;

namespace Application.Catalog.Products
{
    public class ProductService : IProductService
    {
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        private readonly IStorageService _storageService;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(
            IStorageService storageService,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _storageService = storageService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddImageAsync(int productId, ProductImageCreateRequest request)
        {
            var productImage = new ProductImage()
            {
                Caption = request.Caption,
                DateCreated = DateTime.Now,
                IsDefault = request.IsDefault,
                ProductId = productId,
                SortOrder = request.SortOrder
            };

            if (request.ImageFile != null)
            {
                productImage.ImagePath = await SaveFileAsync(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            await _unitOfWork.CommitAsync();

            return true;
        }

        public Task AddViewcountAsync(int productId)
        {
            //get exist product
            var existedProduct = _unitOfWork.Products.GetSingleById(productId)
                ?? throw new AppException(ErrorMessages.ProductNotFound);

            existedProduct.ViewCount += 1;
            _unitOfWork.Products.Update(existedProduct);

            return _unitOfWork.CommitAsync();
        }

        public Task<ApiResult<bool>> CategoryAssignAsync(int id, CategoryAssignRequest request)
        {
            throw new NotImplementedException();
        }

        //public async Task<ApiResult<bool>> CategoryAssignAsync(int id, CategoryAssignRequest request)
        //{
        //    throw new NotImplementedException();
        //    var user = _productRepository.GetSingleById(id);
        //    if (user == null)
        //    {
        //        return new ApiErrorResult<bool>($"Sản phẩm với id {id} không tồn tại");
        //    }
        //    foreach (var category in request.Categories)
        //    {
        //        var productInCategory = await _productInCategory
        //            .FirstOrDefaultAsync(x => x.CategoryId == int.Parse(category.Id)
        //            && x.ProductId == id);
        //        if (productInCategory != null && category.Selected == false)
        //        {
        //            _productInCategory.Remove(productInCategory);
        //        }
        //        else if (productInCategory == null && category.Selected)
        //        {
        //            await _productInCategory.AddAsync(new ProductInCategory()
        //            {
        //                CategoryId = int.Parse(category.Id),
        //                ProductId = id
        //            });
        //        }
        //    }
        //    await _unitOfWork.CommitAsync();
        //    return new ApiSuccessResult<bool>();
        //}

        public async Task<bool> CreateAsync(ProductCreateRequest request, string userId)
        {
            // get product translations
            //var languages = _context.Languages;
            var languages = SystemConstants.GetSystemLanguages();

            // map data
            var productEntity = await MapCreateProduct(request, languages, userId);

            //save product
            _unitOfWork.Products.Add(productEntity);

            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> DeleteAsync(int productId)
        {
            var existedProduct = _unitOfWork.Products.GetSingleById(productId)
                ?? throw new AppException(ErrorMessages.ProductNotFound);

            // delete product image
            var images = await _unitOfWork.ProductImages.GetImagesAsync(productId);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }

            //remove product
            _unitOfWork.Products.Delete(existedProduct);

            return await _unitOfWork.CommitAsync();
        }

        public async Task<PagedResult<ProductVm>> GetAllByCategoryIdAsync(string languageId, GetPublicProductPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<ProductVm>> GetAllPagingAsync(GetManageProductPagingRequest request)
        {
            return _unitOfWork.Products.GetAllPagingAsync(request);
        }

        public async Task<ProductVm> GetByIdAsync(int productId, string languageId)
        {
            return _mapper.Map<ProductVm>(await _unitOfWork.Products.GetByIdAsync(productId, languageId));
        }

        public Task<List<ProductVm>> GetFeaturedProductsAsync(string languageId, int take)
        {
            return _unitOfWork.Products.GetFeaturedProductsAsync(languageId, take);
        }

        public async Task<ProductImageViewModel> GetImageByIdAsync(int imageId)
        {
            var image = _unitOfWork.ProductImages.GetSingleById(imageId);
            if (image == null)
                throw new AppException(ErrorMessages.ProductImageNotFound);

            return _mapper.Map<ProductImageViewModel>(image);
        }

        public Task<List<ProductVm>> GetLatestProductsAsync(string languageId, int take)
        {
            return _unitOfWork.Products.GetLatestProductsAsync(languageId, take);
        }

        public async Task<List<ProductImageViewModel>> GetListImagesAsync(int productId)
        {
            var productImages = await _unitOfWork.ProductImages.GetImagesAsync(productId);

            return _mapper.Map<List<ProductImageViewModel>>(productImages);
        }

        public Task<bool> RemoveImageAsync(int imageId)
        {
            var productImage = _unitOfWork.ProductImages.GetSingleById(imageId);
            if (productImage == null)
                throw new AppException(ErrorMessages.ProductImageNotFound);

            _unitOfWork.ProductImages.Update(productImage);
            return _unitOfWork.CommitAsync();
        }

        public async Task<bool> UpdateAsync(ProductUpdateRequest request, string userId)
        {
            //validate
            var exitedProduct = await _unitOfWork.Products.GetByIdAsync(request.Id, request.LanguageId);

            var productTranslations = _unitOfWork.ProductTranslations.GetProductTranslation(request.Id, request.LanguageId);

            if (exitedProduct == null || productTranslations == null)
                throw new AppException(ErrorMessages.ProductNotFound);

            //map product
            var productEntity = await MapUpdateProduct(exitedProduct, request, productTranslations, userId);

            // save product
            _unitOfWork.Products.Update(productEntity);

            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> UpdateImageAsync(int imageId, ProductImageUpdateRequest request)
        {
            var productImage = _unitOfWork.ProductImages.GetSingleById(imageId);
            if (productImage == null)
                throw new AppException(ErrorMessages.ProductImageNotFound);

            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFileAsync(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }

            _unitOfWork.ProductImages.Update(productImage);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> UpdatePriceAsync(int productId, decimal newPrice)
        {
            var product = _unitOfWork.Products.GetSingleById(productId);
            if (product == null)
                throw new AppException(ErrorMessages.ProductNotFound);

            product.Price = newPrice;
            await _unitOfWork.Products.UpdateAsync(product);

            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> UpdateStockAsync(int productId, int addedQuantity)
        {
            var product = _unitOfWork.Products.GetSingleById(productId);
            if (product == null)
                throw new AppException(ErrorMessages.ProductNotFound);

            product.Stock += addedQuantity;
            await _unitOfWork.Products.UpdateAsync(product);

            return await _unitOfWork.CommitAsync();
        }

        private async Task<Product> MapCreateProduct(ProductCreateRequest request, List<Language> languages, string userId)
        {
            var translations = new List<ProductTranslation>();
            foreach (var language in languages)
            {
                if (language.Id == request.LanguageId)
                {
                    translations.Add(new ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId
                    });
                }
                else
                {
                    translations.Add(new ProductTranslation()
                    {
                        Name = SystemConstants.ProductConstants.NA,
                        Description = SystemConstants.ProductConstants.NA,
                        SeoAlias = SystemConstants.ProductConstants.NA,
                        LanguageId = language.Id
                    });
                }
            }
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                //CreatedBy = userId,
                ProductTranslations = translations
            };

            //Save image
            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Thumbnail image",
                        DateCreated = DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath = await SaveFileAsync(request.ThumbnailImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }

            return product;
        }

        private async Task<Product> MapUpdateProduct(Product exitedProduct, ProductUpdateRequest request, ProductTranslation productTranslations, string userId)
        {
            productTranslations.Name = request.Name;
            productTranslations.SeoAlias = request.SeoAlias;
            productTranslations.SeoDescription = request.SeoDescription;
            productTranslations.SeoTitle = request.SeoTitle;
            productTranslations.Description = request.Description;
            productTranslations.Details = request.Details;

            //Save image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = _unitOfWork.ProductImages.GetDefaultProductImage(request.Id);

                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await SaveFileAsync(request.ThumbnailImage);
                    _unitOfWork.ProductImages.Update(thumbnailImage);
                }
            }
            exitedProduct.ProductTranslations = new List<ProductTranslation>() { productTranslations };
            //exitedProduct.UpdatedBy = userId;

            return exitedProduct;
        }

        private async Task<string> SaveFileAsync(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }
    }
}