using Project.Common;
using Project.DAL.Entities;
using Project.Models.Common;
using Project.Repository.Common;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public  class VehicleModelService : IVehicleModelService
    {
        protected IVehicleModelRepository Repository { get; private set; }

        public VehicleModelService(IVehicleModelRepository repository)
        {
            Repository = repository;
        }

        public async Task AddVehicleModelAsync(IVehicleModel entity)
        {
            Repository.AddVehicleModelAsync(entity);
            await Repository.CommitAsync();
        }

        public async Task DeleteVehicleModelAsync(int id)
        {
            await Repository.DeleteVehicleModelAsync(id);
            await Repository.CommitAsync();
        }

        public async Task<ICollection<IVehicleModel>> GetVehicleModelAsync(GetParams<VehicleModelEntity> getParams)
        {
            return await Repository.GetVehicleModelAsync();
        }

        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {
            return await Repository.GetVehicleModelAsync(id);
        }

        public async Task UpdateVehicleModelAsync(IVehicleModel entity)
        {
            await Repository.UpdateVehicleModelAsync(entity);
            await Repository.CommitAsync();
        }
    }
}
