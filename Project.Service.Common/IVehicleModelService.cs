using Project.Common;
using Project.DAL.Entities;
using Project.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleModelService
    {
        Task<ICollection<IVehicleModel>> GetVehicleModelAsync(GetParams getParams);

        Task<IVehicleModel> GetVehicleModelAsync(int id);

        Task AddVehicleModelAsync(IVehicleModel entity);

        Task UpdateVehicleModelAsync(IVehicleModel entity);

        Task DeleteVehicleModelAsync(int id);
    }
}
