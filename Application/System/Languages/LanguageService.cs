using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Common;
using ViewModels.System.Languages;

namespace Application.System.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly IConfiguration _config;

        public LanguageService(
            IConfiguration config)
        {
            _config = config;
        }

        public async Task<ApiResult<List<LanguageVm>>> GetAllAsync()
        {
            throw new NotImplementedException();
            //var languages = await _context.Languages.Select(x => new LanguageVm()
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    IsDefault = x.IsDefault
            //}).ToListAsync();
            //return new ApiSuccessResult<List<LanguageVm>>(languages);
        }
    }
}