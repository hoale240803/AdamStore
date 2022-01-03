using System.Collections.Generic;
using ViewModels.Common;

namespace Application.Common.Model
{
    public class Response<T>
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T Content { get; set; }
        public IEnumerable<T> Contents { get; set; }

        public PagedList<T> Results { get; set; }
    }
}