using Autofac;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Repository
{
    public class RepositoryDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VehicleMakeRepository>().As<IVehicleMakeRepository>();
            builder.RegisterType<VehicleModelRepository>().As<IVehicleModelRepository>();
        }
    }
}
