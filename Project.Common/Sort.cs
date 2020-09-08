using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Project.Common
{
    public enum SortOrders
    {
        Asc = 1,
        Desc = 2
    }

    public class SortingParams
    {
        public SortOrders SortOrder { get; set; } = SortOrders.Asc;
        public string ColumnName { get; set; }
    }

    public class Sort<T> where T : class
    {
        public static IEnumerable<T> SortData(IEnumerable<T> data, IEnumerable<SortingParams> sortingParams)
        {
            if (sortingParams == null)
            {
                return data;
            }

            IOrderedEnumerable<T> sortedData = null;

            foreach (var sortingParam in sortingParams.Where(x => !String.IsNullOrEmpty(x.ColumnName)))
            {
                PropertyInfo col = typeof(T).GetProperty(sortingParam.ColumnName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);

                if (col != null)
                {
                    sortedData = sortedData == null ? sortingParam.SortOrder == SortOrders.Asc ? data.OrderBy(x => col.GetValue(x, null))
                                                                                               : data.OrderByDescending(x => col.GetValue(x, null))
                                                    : sortingParam.SortOrder == SortOrders.Asc ? sortedData.ThenBy(x => col.GetValue(x, null))
                                                                                        : sortedData.ThenByDescending(x => col.GetValue(x, null));
                }
            }
            return sortedData ?? data;
        }
    }
}
