using Microsoft.EntityFrameworkCore;
using Moq;
using Project.Common;
using Project.DAL.Contexts;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public class TestContext : IVehicleContext
    {
        public DbSet<VehicleMakeEntity> Makes { get; set; }
        public DbSet<VehicleModelEntity> Models { get; set; }

        public TestContext()
        {
            Makes = MoqHelper.GetQueryableMockDbSet(new List<VehicleMakeEntity>()
            {
                new VehicleMakeEntity()
                {
                    Id = 1,
                    Name = "BMW",
                    Abrv = "BMW"
                },
                new VehicleMakeEntity()
                {
                    Id = 2,
                    Name = "Volkswagen",
                    Abrv = "VW"
                },
                new VehicleMakeEntity()
                {
                    Id = 3,
                    Name = "General Motors",
                    Abrv = "GM"
                }
            });

            Models = MoqHelper.GetQueryableMockDbSet(new List<VehicleModelEntity>()
            {
                new VehicleModelEntity()
                {
                    Id = 1,
                    MakeId = 1,
                    Name = "X5",
                    Abrv = "X5"
                },
                new VehicleModelEntity()
                {
                    Id = 2,
                    MakeId = 1,
                    Name = "E36",
                    Abrv = "E36"
                },
                new VehicleModelEntity()
                {
                    Id = 3,
                    MakeId = 2,
                    Name = "Passat",
                    Abrv = "PASSAT"
                },
                new VehicleModelEntity()
                {
                    Id = 4,
                    MakeId = 3,
                    Name = "GMC",
                    Abrv = "GMC"
                }
            });
        }

        public ValueTask DisposeAsync()
        {
            return new ValueTask();
        }

        public Task<int> SaveChangesAsync()
        {
            return new Task<int>(() => 1);
        }
    }
}
