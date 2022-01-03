using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Utilities.Slides;

namespace Application.Ultilities.Slides
{
    public interface ISlideService
    {
        Task<List<SlideVm>> GetAll();
    }
}