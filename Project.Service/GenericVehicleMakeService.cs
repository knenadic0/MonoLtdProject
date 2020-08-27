using AutoMapper;
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

        public async Task<IEnumerable<IVehicleMake>> GetVehicleMakeAsync(Expression<Func<VehicleMakeEntity, bool>> filter = null,
            Func<IQueryable<VehicleMakeEntity>, IOrderedQueryable<VehicleMakeEntity>> orderBy = null, string includeProperties = "", int page = 1)
        {
            //Expression<Func<VehicleMakeEntity, bool>> filterEntity = 
            //    Mapper.Map<Expression<Func<VehicleMakeEntity, bool>>>(filter);
            //Func<IQueryable<VehicleMakeEntity>, IOrderedQueryable<VehicleMakeEntity>> orderByEntity = 
            //    Mapper.Map<Func<IQueryable<VehicleMakeEntity>, IOrderedQueryable<VehicleMakeEntity>>>(orderBy);

            return Mapper.Map<ICollection<IVehicleMake>>(await Repository.Get(filter, orderBy, includeProperties, page));
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
