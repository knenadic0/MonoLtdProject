using Autofac;
using AutoMapper;
using Project.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WebAPI.Modules
{
    public class WebAPIDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mapper>().As<IMapper>();
        }
    }
}
