using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Contexts;
using Project.DAL.Entities;
using Project.Models.Common;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Project.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository, IDisposable
    {
        private readonly IMapper mapper;

        protected IVehicleContext Context { get; private set; }

        public VehicleModelRepository(IVehicleContext context, IMapper mapper)
        {
            Context = context;
            this.mapper = mapper;
        }

        public async void Dispose()
        {
            await Context.DisposeAsync();
        }

        public async Task<ICollection<IVehicleModel>> GetVehicleModelAsync()
        {
            return new List<IVehicleModel>(mapper.Map<List<IVehicleModel>>(await Context.Models.Include(x => x.Make).AsNoTracking().ToListAsync()));
        }

        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {
            return mapper.Map<IVehicleModel>(await Context.Models.AsNoTracking().Include(x => x.Make).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id));
        }

        public void AddVehicleModelAsync(IVehicleModel entity)
        {
            Context.Models.Add(mapper.Map<VehicleModelEntity>(entity));
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
        }

        public async Task DeleteVehicleModelAsync(int id)
        {
            VehicleModelEntity modelEntity = await Context.Models.FirstOrDefaultAsync(x => x.Id == id);

            if (modelEntity == null)
            {
                throw new InvalidOperationException();
            }

            Context.Models.Remove(modelEntity);
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
