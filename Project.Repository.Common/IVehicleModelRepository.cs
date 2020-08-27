using Project.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IVehicleModelRepository : IDisposable
    {
        Task<ICollection<IVehicleModel>> GetVehicleModelAsync();

        Task<IVehicleModel> GetVehicleModelAsync(int id);

        void AddVehicleModelAsync(IVehicleModel entity);

        Task UpdateVehicleModelAsync(IVehicleModel entity);

        Task DeleteVehicleModelAsync(int id);

        Task<int> CommitAsync();
    }
}
