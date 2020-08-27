using AutoMapper;
using Project.DAL.Entities;
using Project.Models;
using Project.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Repository
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<VehicleModel, VehicleModelEntity>().PreserveReferences();
            CreateMap<VehicleModelEntity, VehicleModel>().PreserveReferences();
            CreateMap<VehicleModelEntity, IVehicleModel>().PreserveReferences();
            CreateMap<IVehicleModel, VehicleModelEntity>().PreserveReferences();
        }
    }
}
