using AutoMapper;
using Project.Common;
using Project.DAL.Entities;
using Project.Models.Common;
using Project.Repository;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class GenericVehicleModelService : IVehicleModelService
    {
        protected GenericRepository<VehicleModelEntity> Repository { get; private set; }
        protected IMapper Mapper { get; private set; }
        private readonly UnitOfWork unitOfWork;

        public GenericVehicleModelService(IMapper mapper)
        {
            unitOfWork = new UnitOfWork();
            Repository = unitOfWork.VehicleModelRepository;
            Mapper = mapper;
        }

        public async Task AddVehicleModelAsync(IVehicleModel entity)
        {
            Repository.Insert(Mapper.Map<VehicleModelEntity>(entity));
            await unitOfWork.SaveAsync();
        }

        public async Task DeleteVehicleModelAsync(int id)
        {
            await Repository.DeleteAsync(id);
            await unitOfWork.SaveAsync();
        }

        public async Task<ICollection<IVehicleModel>> GetVehicleModelAsync(GetParams<VehicleModelEntity> getParams)
        {
            return Mapper.Map<ICollection<IVehicleModel>>(await Repository.Get(getParams));
        }

        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {
            return Mapper.Map<IVehicleModel>(await Repository.GetByID(id));
        }

        public async Task UpdateVehicleModelAsync(IVehicleModel entity)
        {
            Repository.Update(Mapper.Map<VehicleModelEntity>(entity));
            await unitOfWork.SaveAsync();
        }
    }
}
