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

namespace Project.Repository
{
    public class VehicleRepository : IVehicleRepository, IDisposable
    {
        protected IVehicleContext Context { get; private set; }

        public VehicleRepository(IVehicleContext context)
        {
            Context = context;
        }

        public async void Dispose()
        {
            await Context.DisposeAsync();
        }

        public async Task<ICollection<IVehicleMake>> GetVehicleMakeAsync()
        {
            return new List<IVehicleMake>(Mapper.Map<List<VehicleMake>>(await Context.Makes.ToListAsync()));
        }

        public async Task<ICollection<IVehicleModel>> GetVehicleModelAsync()
        {
            return new List<IVehicleModel>(Mapper.Map<List<VehicleModel>>(await Context.Models.ToListAsync()));
        }

        public async Task<IVehicleMake> GetVehicleMakeAsync(int id)
        {
            return Mapper.Map<IVehicleMake>(await Context.Makes.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {
            return Mapper.Map<IVehicleModel>(await Context.Models.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task AddVehicleMakeAsync(IVehicleMake entity)
        {
            await Context.Makes.AddAsync(Mapper.Map<VehicleMakeEntity>(entity));
        }

        public async Task AddVehicleModelAsync(IVehicleModel entity)
        {
            await Context.Models.AddAsync(Mapper.Map<VehicleModelEntity>(entity));
        }

        public async Task UpdateVehicleMakeAsync(IVehicleMake entity)
        {
            await Task.Run(() => Context.Makes.Update(Mapper.Map<VehicleMakeEntity>(entity)));
        }

        public async Task UpdateVehicleModelAsync(IVehicleModel entity)
        {
            await Task.Run(() => Context.Models.Update(Mapper.Map<VehicleModelEntity>(entity)));
        }

        public async Task DeleteVehicleMakeAsync(int id)
        {
            Context.Makes.Remove(await Context.Makes.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task DeleteVehicleModelAsync(int id)
        {
            Context.Models.Remove(await Context.Models.FirstOrDefaultAsync(x => x.Id == id));
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
