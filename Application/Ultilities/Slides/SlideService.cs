using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Utilities.Slides;

namespace Application.Ultilities.Slides
{
    public class SlideService : ISlideService
    {
        //private readonly AdamStoreDbContext _context;

        public SlideService()
        {
        }

        public async Task<List<SlideVm>> GetAll()
        {
            throw new NotImplementedException();
            //var slides = await _context.Slides.OrderBy(x => x.SortOrder)
            //    .Select(x => new SlideVm()
            //    {
            //        Id = x.Id,
            //        Name = x.Name,
            //        Description = x.Description,
            //        Url = x.Url,
            //        Image = x.Image
            //    }).ToListAsync();

            //return slides;
        }
    }
}