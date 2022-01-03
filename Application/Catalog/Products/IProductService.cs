using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Catalog.ProductImages;
using ViewModels.Catalog.Products;
using ViewModels.Common;

namespace Application.Catalog.Products
{
    public interface IProductService
    {
        #region Product
        Task<bool> CreateAsync(ProductCreateRequest request, string userId);

        Task<bool> UpdateAsync(ProductUpdateRequest request, string userId);

        Task<bool> DeleteAsync(int productId);

        Task<ProductVm> GetByIdAsync(int productId, string languageId);

        Task<bool> UpdatePriceAsync(int productId, decimal newPrice);

        Task<bool> UpdateStockAsync(int productId, int addedQuantity);

        Task AddViewcountAsync(int productId);

        Task<PagedResult<ProductVm>> GetAllPagingAsync(GetManageProductPagingRequest request);

        #endregion End Product




        Task<bool> AddImageAsync(int productId, ProductImageCreateRequest request);

        Task<bool> RemoveImageAsync(int imageId);

        Task<bool> UpdateImageAsync(int imageId, ProductImageUpdateRequest request);

        Task<ProductImageViewModel> GetImageByIdAsync(int imageId);

        Task<List<ProductImageViewModel>> GetListImagesAsync(int productId);

        Task<PagedResult<ProductVm>> GetAllByCategoryIdAsync(string languageId, GetPublicProductPagingRequest request);

        Task<ApiResult<bool>> CategoryAssignAsync(int id, CategoryAssignRequest request);

        Task<List<ProductVm>> GetFeaturedProductsAsync(string languageId, int take);

        Task<List<ProductVm>> GetLatestProductsAsync(string languageId, int take);
    }
}