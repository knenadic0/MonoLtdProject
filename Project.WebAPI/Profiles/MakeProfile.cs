using AutoMapper;
using Project.Models;
using Project.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WebAPI.Profiles
{
    public class MakeProfile : Profile
    {
        public MakeProfile()
        {
            CreateMap<VehicleMake, VehicleMakeModel>().PreserveReferences();
            CreateMap<VehicleMakeModel, VehicleMake>().PreserveReferences();
        }
    }
}
