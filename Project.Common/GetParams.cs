using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Common
{
    public class GetParams
    {
        public IEnumerable<SortingParams> SortingParams { set; get; }
        public IEnumerable<FilterParams> FilterParam { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
