using Autofac;
using Project.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL
{
    public class DALDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VehicleContext>().As<IVehicleContext>();
        }
    }
}
