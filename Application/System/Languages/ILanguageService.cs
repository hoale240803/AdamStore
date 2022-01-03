using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Common;
using ViewModels.System.Languages;

namespace Application.System.Languages
{
    public interface ILanguageService
    {
        Task<ApiResult<List<LanguageVm>>> GetAllAsync();
    }
}