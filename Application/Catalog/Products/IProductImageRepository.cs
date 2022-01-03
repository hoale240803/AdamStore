using Application._Abstracts;
using Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Catalog.Products
{
    public interface IProductImageRepository : IRepository<ProductImage>
    {
        ProductImage GetDefaultProductImage(int productId);

        Task<List<ProductImage>> GetImagesAsync(int productId);

        
    }
}