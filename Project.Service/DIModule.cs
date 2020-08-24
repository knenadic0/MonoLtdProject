using System;
using System.Collections.Generic;
using System.Text;
using Ninject.Modules;
using Project.Service.Common;

namespace Project.Service
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleService>().To<VehicleService>();
        }
    }
}
