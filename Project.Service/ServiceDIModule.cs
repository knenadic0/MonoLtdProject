using Autofac;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service
{
    public class ServiceDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GenericVehicleMakeService>().As<IVehicleMakeService>();
            builder.RegisterType<GenericVehicleModelService>().As<IVehicleModelService>();
        }
    }
}
