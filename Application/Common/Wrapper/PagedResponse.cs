using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Wrapper
{
    public class PagedResponse<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public int TotalCount { get; set; }
        public int TotalPages { get; set; }

        public List<T> Items { get; set; } = new();
    }

}
