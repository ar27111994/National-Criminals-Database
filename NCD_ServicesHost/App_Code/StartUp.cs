using Autofac;
using Autofac.Integration.Wcf;
using BusinessServices;
using BusinessServices.MapperConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCDServices.App_Code
{
    public class StartUp
    {
        public static void AppInitialize()
        {
            var builder = new ContainerBuilder();

            //Register WCF Services
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<CriminalService>().As<ICriminalService>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<NationalityService>().As<INationalityService>();

            builder.RegisterModule(new AutoMapperModule());

            // Set the dependency resolver.
            AutofacHostFactory.Container = builder.Build();

        }
    }
}