using AutoMapper;
using Shared.Entities;
using ViewModels.Catalog.Products;

namespace API.Utilities.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductVm>();
            CreateMap<ProductVm, Product>();
        }
    }
}