using AutoMapper;
using Project.DAL.Entities;
using Project.Models;
using Project.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Repository
{
    public class ModelProfiles : Profile
    {
        public ModelProfiles()
        {
            CreateMap<VehicleMake, VehicleMakeEntity>().PreserveReferences();
            CreateMap<VehicleMakeEntity, VehicleMake>().PreserveReferences();
            CreateMap<VehicleMakeEntity, IVehicleMake>().PreserveReferences();
            CreateMap<IVehicleMake, VehicleMakeEntity>().PreserveReferences();

            CreateMap<VehicleModel, VehicleModelEntity>().PreserveReferences();
            CreateMap<VehicleModelEntity, VehicleModel>().PreserveReferences();
            CreateMap<VehicleModelEntity, IVehicleModel>().PreserveReferences();
            CreateMap<IVehicleModel, VehicleModelEntity>().PreserveReferences();
        }
    }
}
