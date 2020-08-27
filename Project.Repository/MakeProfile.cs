using AutoMapper;
using Project.DAL.Entities;
using Project.Models;
using Project.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Repository
{
    public class MakeProfile : Profile
    {
        public MakeProfile()
        {
            CreateMap<VehicleMake, VehicleMakeEntity>().PreserveReferences();
            CreateMap<VehicleMakeEntity, VehicleMake>().PreserveReferences();
            CreateMap<VehicleMakeEntity, IVehicleMake>().PreserveReferences();
            CreateMap<IVehicleMake, VehicleMakeEntity>().PreserveReferences();
        }
    }
}
