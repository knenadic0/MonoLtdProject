using AutoMapper;
using Project.Common;
using Project.DAL.Entities;
using Project.Models;
using Project.Models.Common;
using Project.Repository;
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
    public class GenericVehicleMakeService : IVehicleMakeService
    {
        protected GenericRepository<VehicleMakeEntity> Repository { get; private set; }
        protected IMapper Mapper { get; private set; }
        private readonly UnitOfWork unitOfWork;

        public GenericVehicleMakeService(IMapper mapper)
        {
            unitOfWork = new UnitOfWork();
            Repository = unitOfWork.VehicleMakeRepository;
            Mapper = mapper;
        }

        public async Task AddVehicleMakeAsync(IVehicleMake entity)
        {
            Repository.Insert(Mapper.Map<VehicleMakeEntity>(entity));
            await unitOfWork.SaveAsync();
        }

        public async Task DeleteVehicleMakeAsync(int id)
        {
            await Repository.DeleteAsync(id);
            await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<IVehicleMake>> GetVehicleMakeAsync(GetParams<VehicleMake> getParams)
        {
            return Mapper.Map<ICollection<IVehicleMake>>(await Repository.Get(Mapper.Map<GetParams<VehicleMakeEntity>>(getParams)));
        }

        public async Task<IVehicleMake> GetVehicleMakeAsync(int id)
        {
            return Mapper.Map<IVehicleMake>(await Repository.GetByID(id));
        }

        public async Task UpdateVehicleMakeAsync(IVehicleMake entity)
        {
            Repository.Update(Mapper.Map<VehicleMakeEntity>(entity));
            await unitOfWork.SaveAsync();
        }
    }
}
