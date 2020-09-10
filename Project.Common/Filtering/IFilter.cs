using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Common.Filtering
{
    public interface IFilter<T>
    {
        public IQueryable<T> FilteredData(IQueryable<T> data, IEnumerable<FilterParams> filterParams);
    }
}
