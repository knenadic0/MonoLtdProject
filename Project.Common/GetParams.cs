using Project.Common.Filtering;
using Project.Common.Paging;
using Project.Common.Sorting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Common
{
    public class GetParams<T> where T : class
    {
        public IEnumerable<SortingParams> SortingParam { set; get; }
        public IEnumerable<FilterParams> FilterParam { get; set; }
        public IEnumerable<string> SelectParam { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public IFilter Filter { get; set; }
        public ISort Sort { get; set; }
        public IPage Page { get; set; }
    }
}
