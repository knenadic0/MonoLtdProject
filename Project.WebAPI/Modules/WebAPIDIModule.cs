using Autofac;
using AutoMapper;
using Project.Common;
using Project.Common.Filtering;
using Project.Common.Paging;
using Project.Common.Sorting;
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
            builder.RegisterType<Filter>().As<IFilter>();
            builder.RegisterType<Sort>().As<ISort>();
            builder.RegisterType<PagedResult>().As<IPage>();
        }
    }
}
