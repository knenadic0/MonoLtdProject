using Project.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IVehicleRepository : IDisposable
    {
        ICollection<IVehicleMake> GetVehicleMakeAsync();
        ICollection<IVehicleModel> GetVehicleModelAsync();

        IVehicleMake GetVehicleMakeAsync(int id);
        IVehicleModel GetVehicleModelAsync(int id);

        void AddVehicleMakeAsync(IVehicleMake entity);
        void AddVehicleModelAsync(IVehicleModel entity);

        void UpdateVehicleMakeAsync(IVehicleMake entity);
        void UpdateVehicleModelAsync(IVehicleModel entity);

        void DeleteVehicleMakeAsync(IVehicleMake entity);
        void DeleteVehicleModelAsync(IVehicleModel entity);

        Task<int> CommitAsync();
    }
}
