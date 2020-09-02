using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Common
{
    public static class Include
    {
        public static IQueryable<TEntity> IncludeEntities<TEntity>(this IQueryable<TEntity> dataSet, string entities) where TEntity : class
        {
            foreach (var includeProperty in entities.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                try
                {
                    dataSet = dataSet.Include(includeProperty);
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return dataSet;
        }
    }
}
