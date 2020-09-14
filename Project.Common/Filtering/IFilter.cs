using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Common.Filtering
{
    public interface IFilter
    {
        public IQueryable<T> FilteredData<T>(IQueryable<T> data, IEnumerable<FilterParams> filterParams);
    }
}
