using Project.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleService
    {
        Task<ICollection<IVehicleMake>> GetVehicleMakeAsync();
        Task<ICollection<IVehicleModel>> GetVehicleModelAsync();

        Task<IVehicleMake> GetVehicleMakeAsync(int id);
        Task<IVehicleModel> GetVehicleModelAsync(int id);

        Task AddVehicleMakeAsync(IVehicleMake entity);
        Task AddVehicleModelAsync(IVehicleModel entity);

        Task UpdateVehicleMakeAsync(IVehicleMake entity);
        Task UpdateVehicleModelAsync(IVehicleModel entity);

        Task DeleteVehicleMakeAsync(int id);
        Task DeleteVehicleModelAsync(int id);
    }
}
