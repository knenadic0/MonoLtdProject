using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Project.Common
{
    public static class Filter
    {
        public static IQueryable<TEntity> FilterSet<TEntity>(this IQueryable<TEntity> dataSet, Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            if (filter != null)
            {
                try
                {
                    return dataSet.Where(filter);
                }
                catch (Exception)
                {

                    return dataSet;
                }
            }
            else
            {
                return dataSet;
            }
        }
    }
}
