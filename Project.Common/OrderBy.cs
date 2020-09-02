using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Common
{
    public static class OrderBy
    {
        public static IQueryable<TEntity> Order<TEntity>(this IQueryable<TEntity> dataSet, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null) where TEntity : class
        {
            if (orderBy == null)
            {
                return dataSet;
            }
            else 
            {
                try
                {
                    return orderBy(dataSet);
                }
                catch (Exception)
                {
                    return dataSet;
                }
            }
        }
    }
}
