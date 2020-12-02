using Autofac;
using Autofac.Integration.Mvc;
using FreeRecycle.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreeRecycle.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {

            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SqlItemData>()
                   .As<IItemData>()
                   .InstancePerRequest();
            builder.RegisterType<FreeRecycleDBContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        
        }
    }
}