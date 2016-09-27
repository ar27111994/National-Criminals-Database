using Autofac;
using Autofac.Core;
using BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTests
{
    public class IoCSupportedTest<TModule> where TModule : IModule, new()
    {
        private IContainer container;

        public IoCSupportedTest()
        {
            var builder = new ContainerBuilder();
            //Register WCF Services
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<CriminalService>().As<ICriminalService>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<NationalityService>().As<INationalityService>();


            builder.RegisterModule(new TModule());

            container = builder.Build();
        }

        protected TEntity Resolve<TEntity>()
        {
            return container.Resolve<TEntity>();
        }

        protected void ShutdownIoC()
        {
            container.Dispose();
        }
    }
}
