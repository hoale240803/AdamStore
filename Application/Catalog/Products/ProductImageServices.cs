using Application._Abstracts;
using Application.Common;
using AutoMapper;

namespace Application.Catalog.Products
{
    public class ProductImageServices : IProductImageService
    {
        private readonly IProductRepository _productRepository;

        //private readonly AdamStoreDbContext _context;
        private readonly IStorageService _storageService;

        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ProductImageServices(IStorageService storageService, IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _storageService = storageService;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}