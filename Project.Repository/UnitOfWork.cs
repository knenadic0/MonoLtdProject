using Project.DAL;
using Project.DAL.Entities;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class UnitOfWork : IDisposable
    {
        private VehicleContext context = new VehicleContext();
        private GenericRepository<VehicleMakeEntity> vehicleMakeRepository;
        private GenericRepository<VehicleModelEntity> vehicleModelRepository;

        public GenericRepository<VehicleMakeEntity> VehicleMakeRepository
        {
            get
            {

                if (this.vehicleMakeRepository == null)
                {
                    this.vehicleMakeRepository = new GenericRepository<VehicleMakeEntity>(context);
                }
                return vehicleMakeRepository;
            }
        }

        public GenericRepository<VehicleModelEntity> VehicleModelRepository
        {
            get
            {

                if (this.vehicleModelRepository == null)
                {
                    this.vehicleModelRepository = new GenericRepository<VehicleModelEntity>(context);
                }
                return vehicleModelRepository;
            }
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
