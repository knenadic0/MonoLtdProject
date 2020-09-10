using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Project.DAL;
using System.Threading.Tasks;
using PagedList;
using Project.Common;
using Project.Common.Filtering;
using Project.Common.Sorting;
using Project.Common.Paging;

namespace Project.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal VehicleContext context;
        internal DbSet<TEntity> dbSet;
        private readonly IFilter<TEntity> filter;
        private readonly ISort<TEntity> sorter;
        private readonly IPage pager;

        public GenericRepository(VehicleContext context, IFilter<TEntity> filter, ISort<TEntity> sorter, IPage pager)
        {
            this.context = context;
            this.filter = filter;
            this.sorter = sorter;
            this.pager = pager;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> Get(GetParams<TEntity> getParams)
        {
            IQueryable<TEntity> query = dbSet;

            query = filter.FilteredData(query, getParams.FilterParam);
            query = sorter.SortData(query, getParams.SortingParam);
            return (await pager.GetPagedAsync(query, getParams.PageNumber, getParams.PageSize)).Results;
        }

        public virtual async Task<TEntity> GetByID(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual async Task DeleteAsync(object id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}