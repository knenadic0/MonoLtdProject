using AutoMapper;
using Project.Models;
using Project.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WebAPI.Profiles
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<VehicleModel, VehicleModelModel>().PreserveReferences();
            CreateMap<VehicleModelModel, VehicleModel>().PreserveReferences();
        }
    }
}
