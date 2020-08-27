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
using System.Security.Cryptography.X509Certificates;

namespace Project.Repository
{
    public class VehicleRepository : IVehicleRepository, IDisposable
    {
        private readonly IMapper mapper;

        protected IVehicleContext Context { get; private set; }

        public VehicleRepository(IVehicleContext context, IMapper mapper)
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

        public async Task<ICollection<IVehicleModel>> GetVehicleModelAsync()
        {
            return new List<IVehicleModel>(mapper.Map<List<IVehicleModel>>(await Context.Models.Include(x => x.Make).AsNoTracking().ToListAsync()));
        }

        public async Task<IVehicleMake> GetVehicleMakeAsync(int id)
        {
            return mapper.Map<IVehicleMake>(await Context.Makes.AsNoTracking().Include(x => x.Models).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {
            return mapper.Map<IVehicleModel>(await Context.Models.AsNoTracking().Include(x => x.Make).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task AddVehicleMakeAsync(IVehicleMake entity)
        {
            Context.Makes.Add(mapper.Map<VehicleMakeEntity>(entity));
            await CommitAsync();
        }

        public async Task AddVehicleModelAsync(IVehicleModel entity)
        {
            Context.Models.Add(mapper.Map<VehicleModelEntity>(entity));
            await CommitAsync();
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

            await CommitAsync();
        }

        public async Task UpdateVehicleModelAsync(IVehicleModel entity)
        {
            VehicleModelEntity modelEntity = await Context.Models.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);
            VehicleMakeEntity make = await Context.Makes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.MakeId);

            if (string.IsNullOrEmpty(entity.Name) || string.IsNullOrEmpty(entity.Abrv) || modelEntity == null || make == null)
            {
                throw new InvalidOperationException();
            }

            Context.Models.Attach(modelEntity);
            
            modelEntity.Name = entity.Name;
            modelEntity.Abrv = entity.Abrv;
            modelEntity.MakeId = entity.MakeId;

            await CommitAsync();
        }

        public async Task DeleteVehicleMakeAsync(int id)
        {
            VehicleMakeEntity makeEntity = await Context.Makes.FirstOrDefaultAsync(x => x.Id == id);

            if (makeEntity == null)
            {
                throw new InvalidOperationException();
            }

            Context.Makes.Remove(makeEntity);
            await CommitAsync();
        }

        public async Task DeleteVehicleModelAsync(int id)
        {
            VehicleModelEntity modelEntity = await Context.Models.FirstOrDefaultAsync(x => x.Id == id);

            if (modelEntity == null)
            {
                throw new InvalidOperationException();
            }

            Context.Models.Remove(modelEntity);
            await CommitAsync();
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
