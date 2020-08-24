using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Contexts
{
    public interface IVehicleContext
    {
        DbSet<VehicleMakeEntity> Makes { get; set; }
        DbSet<VehicleModelEntity> Models { get; set; }

        Task<int> SaveChangesAsync();
        ValueTask DisposeAsync();
    }
}
