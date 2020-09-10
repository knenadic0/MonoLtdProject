using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Common.Sorting
{
    public interface ISort<T>
    {
        public IQueryable<T> SortData(IQueryable<T> data, IEnumerable<SortingParams> sortingParams);
    }
}
