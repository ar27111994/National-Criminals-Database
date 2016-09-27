using Autofac;
using Autofac.Core;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WebUIClient.CriminalServiceReference;
using WebUIClient.NationalityServiceReference;
using WebUIClient.RoleServiceReference;
using WebUIClient.UserServiceReference;
using WebUIClient.MapperConfig;

namespace WebClients.Tests
{
    public class IoCSupportedTest
    {
        private IContainer container;

        public IoCSupportedTest()
        {
            var builder = new ContainerBuilder();

            //Register WCF Services
            builder
              .Register(c => new ChannelFactory<IUserService>(
                new BasicHttpBinding(),
                new EndpointAddress("https://localhost:7743/UserService.svc")))
              .SingleInstance();

            builder
              .Register(c => c.Resolve<ChannelFactory<IUserService>>().CreateChannel())
              .As<IUserService>();

            builder.RegisterType<UserServiceClient>().As<IUserService>();

            builder
              .Register(c => new ChannelFactory<ICriminalService>(
                new BasicHttpBinding(),
                new EndpointAddress("http://localhost:7742/CriminalService.svc")))
              .SingleInstance();

            builder
              .Register(c => c.Resolve<ChannelFactory<ICriminalService>>().CreateChannel())
              .As<ICriminalService>();


            builder.RegisterType<CriminalServiceClient>().As<ICriminalService>();

            builder
              .Register(c => new ChannelFactory<IRoleService>(
                new BasicHttpBinding(),
                new EndpointAddress("http://localhost:7742/RoleService.svc")))
              .SingleInstance();

            builder
              .Register(c => c.Resolve<ChannelFactory<IRoleService>>().CreateChannel())
              .As<IRoleService>();


            builder.RegisterType<RoleServiceClient>().As<IRoleService>();

            builder
              .Register(c => new ChannelFactory<INationalityService>(
                new BasicHttpBinding(),
                new EndpointAddress("http://localhost:7742/NationalityService.svc")))
              .SingleInstance();

            builder
              .Register(c => c.Resolve<ChannelFactory<INationalityService>>().CreateChannel())
              .As<INationalityService>();


            builder.RegisterType<NationalityServiceClient>().As<INationalityService>();


            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new NCDProfile());
            });
            var mapper = mapperConfiguration.CreateMapper();
            builder.RegisterInstance(mapper).As<IMapper>();
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
