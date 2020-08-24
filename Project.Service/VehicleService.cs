using Project.Models.Common;
using Project.Repository.Common;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Service
{
    public class VehicleService : IVehicleService
    {
        protected IVehicleRepository Repository { get; private set; }

        public VehicleService(IVehicleRepository repository)
        {
            Repository = repository;
        }

        public async Task AddVehicleMakeAsync(IVehicleMake entity)
        {
            await Repository.AddVehicleMakeAsync(entity);
        }

        public async Task AddVehicleModelAsync(IVehicleModel entity)
        {
            await Repository.AddVehicleModelAsync(entity);
        }

        public async Task DeleteVehicleMakeAsync(int id)
        {
            await Repository.DeleteVehicleMakeAsync(id);
        }

        public async Task DeleteVehicleModelAsync(int id)
        {
            await Repository.DeleteVehicleModelAsync(id);
        }

        public async Task<ICollection<IVehicleMake>> GetVehicleMakeAsync()
        {
            return await Repository.GetVehicleMakeAsync();
        }

        public async Task<IVehicleMake> GetVehicleMakeAsync(int id)
        {
            return await Repository.GetVehicleMakeAsync(id);
        }

        public async Task<ICollection<IVehicleModel>> GetVehicleModelAsync()
        {
            return await Repository.GetVehicleModelAsync();
        }

        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {
            return await Repository.GetVehicleModelAsync(id);
        }

        public async Task UpdateVehicleMakeAsync(IVehicleMake entity)
        {
            await Repository.UpdateVehicleMakeAsync(entity);
        }

        public async Task UpdateVehicleModelAsync(IVehicleModel entity)
        {
            await Repository.UpdateVehicleModelAsync(entity);
        }
    }
}
