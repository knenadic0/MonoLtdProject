using Project.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IVehicleMakeRepository : IDisposable
    {
        Task<ICollection<IVehicleMake>> GetVehicleMakeAsync();

        Task<IVehicleMake> GetVehicleMakeAsync(int id);

        void AddVehicleMakeAsync(IVehicleMake entity);

        Task UpdateVehicleMakeAsync(IVehicleMake entity);

        Task DeleteVehicleMakeAsync(int id);

        Task<int> CommitAsync();
    }
}
