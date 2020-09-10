using Project.Common;
using Project.DAL.Entities;
using Project.Models;
using Project.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<IVehicleMake>> GetVehicleMakeAsync(GetParams<VehicleMake> getParams);

        Task<IVehicleMake> GetVehicleMakeAsync(int id);

        Task AddVehicleMakeAsync(IVehicleMake entity);

        Task UpdateVehicleMakeAsync(IVehicleMake entity);

        Task DeleteVehicleMakeAsync(int id);
    }
}
