using Project.DAL.Contexts;
using Project.Models.Common;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project.Models;
using Project.DAL.Entities;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Castle.DynamicProxy.Generators;

namespace Project.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository, IDisposable
    {
        private readonly IMapper mapper;

        protected IVehicleContext Context { get; private set; }

        public VehicleMakeRepository(IVehicleContext context, IMapper mapper)
        {
            Context = context;
            this.mapper = mapper;
        }

        public async void Dispose()
        {
            await Context.DisposeAsync();
        }

        public async Task<ICollection<IVehicleMake>> GetVehicleMakeAsync()
        {
            return new List<IVehicleMake>(mapper.Map<List<IVehicleMake>>(await Context.Makes.Include(x => x.Models).AsNoTracking().ToListAsync()));
        }

        public async Task<IVehicleMake> GetVehicleMakeAsync(int id)
        {
            return mapper.Map<IVehicleMake>(await Context.Makes.AsNoTracking().Include(x => x.Models).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id));
        }

        public void AddVehicleMakeAsync(IVehicleMake entity)
        {
            Context.Makes.Add(mapper.Map<VehicleMakeEntity>(entity));
        }

        public async Task UpdateVehicleMakeAsync(IVehicleMake entity)
        {
            VehicleMakeEntity makeEntity = await Context.Makes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (string.IsNullOrEmpty(entity.Name) || string.IsNullOrEmpty(entity.Abrv) || makeEntity == null)
            {
                throw new InvalidOperationException();
            }

            Context.Makes.Attach(makeEntity);

            makeEntity.Name = entity.Name;
            makeEntity.Abrv = entity.Abrv;
        }

        public async Task DeleteVehicleMakeAsync(int id)
        {
            VehicleMakeEntity makeEntity = await Context.Makes.FirstOrDefaultAsync(x => x.Id == id);

            if (makeEntity == null)
            {
                throw new InvalidOperationException();
            }

            Context.Makes.Remove(makeEntity);
        }

        public async Task<int> CommitAsync()
        {
            int result = 0;

            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                result = await Context.SaveChangesAsync();
                scope.Complete();
            }

            return result;
        }
    }
}
