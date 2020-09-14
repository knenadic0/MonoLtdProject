using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Common.Sorting
{
    public interface ISort
    {
        public IQueryable<T> SortData<T>(IQueryable<T> data, IEnumerable<SortingParams> sortingParams);
    }
}
