using Project.Common;
using Project.DAL.Entities;
using Project.Models.Common;
using Project.Repository.Common;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        protected IVehicleMakeRepository Repository { get; private set; }

        public VehicleMakeService(IVehicleMakeRepository repository)
        {
            Repository = repository;
        }

        public async Task AddVehicleMakeAsync(IVehicleMake entity)
        {
            Repository.AddVehicleMakeAsync(entity);
            await Repository.CommitAsync();
        }

        public async Task DeleteVehicleMakeAsync(int id)
        {
            await Repository.DeleteVehicleMakeAsync(id);
            await Repository.CommitAsync();
        }

        public async Task<IEnumerable<IVehicleMake>> GetVehicleMakeAsync(GetParams getParams)
        {
            return await Repository.GetVehicleMakeAsync();
        }

        public async Task<IVehicleMake> GetVehicleMakeAsync(int id)
        {
            return await Repository.GetVehicleMakeAsync(id);
        }

        public async Task UpdateVehicleMakeAsync(IVehicleMake entity)
        {
            await Repository.UpdateVehicleMakeAsync(entity);
            await Repository.CommitAsync();
        }
    }
}
