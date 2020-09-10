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

namespace Project.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal VehicleContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(VehicleContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> Get(GetParams<TEntity> getParams)
        {
            IQueryable<TEntity> query = dbSet;

            query = Filter<TEntity>.FilteredData(query, getParams.FilterParam);
            query = Sort<TEntity>.SortData(query, getParams.SortingParam);
            return (await PagedResult<TEntity>.GetPagedAsync(query, getParams.PageNumber, getParams.PageSize)).Results;
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