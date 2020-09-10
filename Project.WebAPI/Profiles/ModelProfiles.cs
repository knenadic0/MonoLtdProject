using AutoMapper;
using Project.Common;
using Project.DAL.Entities;
using Project.Models;
using Project.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WebAPI.Profiles
{
    public class ModelProfiles : Profile
    {
        public ModelProfiles()
        {
            CreateMap<VehicleMake, VehicleMakeModel>().PreserveReferences();
            CreateMap<VehicleMakeModel, VehicleMake>().PreserveReferences();

            CreateMap<VehicleModel, VehicleModelModel>().PreserveReferences();
            CreateMap<VehicleModelModel, VehicleModel>().PreserveReferences();
        }
    }
}
