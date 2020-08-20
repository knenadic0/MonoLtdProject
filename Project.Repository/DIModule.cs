using System;
using System.Collections.Generic;
using System.Text;
using Ninject.Modules;
using AutoMapper;
using Project.DAL.Entities;
using Project.Models;
using Project.Models.Common;

namespace Project.Repository
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Mapper.CreateMap<VehicleMakeEntity, VehicleMake>().ReverseMap();
            Mapper.CreateMap<VehicleMakeEntity, IVehicleMake>().ReverseMap();
            Mapper.CreateMap<IVehicleMake, VehicleMake>().ReverseMap();

            Mapper.CreateMap<VehicleModelEntity, VehicleModel>().ReverseMap();
            Mapper.CreateMap<VehicleModelEntity, IVehicleModel>().ReverseMap();
            Mapper.CreateMap<IVehicleModel, VehicleModel>().ReverseMap();
        }
    }
}
