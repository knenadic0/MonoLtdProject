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

namespace Project.Repository
{
    public class VehicleRepository : IVehicleRepository, IDisposable
    {
        public IVehicleContext Context { get; private set; }

        public VehicleRepository(IVehicleContext context)
        {
            Context = context;
        }

        public async void Dispose()
        {
            await Context.DisposeAsync();
        }

        public ICollection<IVehicleMake> GetVehicleMakeAsync()
        {
            return new List<IVehicleMake>(Mapper.Map<List<VehicleMake>>(Context.Makes));
        }

        public ICollection<IVehicleModel> GetVehicleModelAsync()
        {
            return new List<IVehicleModel>(Mapper.Map<List<VehicleModel>>(Context.Models));
        }

        public IVehicleMake GetVehicleMakeAsync(int id)
        {
            return Mapper.Map<VehicleMake>(Context.Makes.FirstOrDefault(x => x.Id == id));
        }

        public IVehicleModel GetVehicleModelAsync(int id)
        {
            return Mapper.Map<VehicleModel>(Context.Models.FirstOrDefault(x => x.Id == id));
        }

        public void AddVehicleMakeAsync(IVehicleMake entity)
        {
            Context.Makes.Add(Mapper.Map<VehicleMakeEntity>(entity));
        }

        public void AddVehicleModelAsync(IVehicleModel entity)
        {
            Context.Models.Add(Mapper.Map<VehicleModelEntity>(entity));
        }

        public void UpdateVehicleMakeAsync(IVehicleMake entity)
        {
            Context.Makes.Update(Mapper.Map<VehicleMakeEntity>(entity));
        }

        public void UpdateVehicleModelAsync(IVehicleModel entity)
        {
            Context.Models.Update(Mapper.Map<VehicleModelEntity>(entity));
        }

        public void DeleteVehicleMakeAsync(IVehicleMake entity)
        {
            Context.Makes.Remove(Mapper.Map<VehicleMakeEntity>(entity));
        }

        public void DeleteVehicleModelAsync(IVehicleModel entity)
        {
            Context.Models.Remove(Mapper.Map<VehicleModelEntity>(entity));
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
