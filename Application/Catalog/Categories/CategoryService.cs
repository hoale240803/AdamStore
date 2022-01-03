using Application._Abstracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Catalog.Categories;

namespace Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<CategoryVm>> GetAllAsync(string languageId)
        {
            throw new NotImplementedException();
            //var query = from c in _context.Categories
            //            join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
            //            where ct.LanguageId == languageId
            //            select new { c, ct };
            //return query.Select(x => new CategoryVm()
            //{
            //    Id = x.c.Id,
            //    Name = x.ct.Name,
            //    ParentId = x.c.ParentId
            //}).ToListAsync();
        }

        public Task<CategoryVm> GetByIdAsync(string languageId, int id)
        {
            throw new NotImplementedException();
            //var query = from c in _context.Categories
            //            join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
            //            where ct.LanguageId == languageId && c.Id == id
            //            select new { c, ct };
            //return query.Select(x => new CategoryVm()
            //{
            //    Id = x.c.Id,
            //    Name = x.ct.Name,
            //    ParentId = x.c.ParentId
            //}).FirstOrDefaultAsync();
        }
    }
}