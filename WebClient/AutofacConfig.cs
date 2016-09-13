using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using WebUIClient.UserServiceReference;
using WebUIClient.CriminalServiceReference;
using WebUIClient.RoleServiceReference;
using WebUIClient.NationalityServiceReference;
using AutoMapper;
using WebUIClient.MapperConfig;
using System.ServiceModel;

namespace WebUIClient
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            //Register WCF Services
            builder
              .Register(c => new ChannelFactory<IUserService>(
                new WebHttpBinding(),
                new EndpointAddress("https://localhost:7743/UserService.svc")))
              .SingleInstance();

            builder
              .Register(c => c.Resolve<ChannelFactory<IUserService>>().CreateChannel())
              .As<IUserService>();

            builder.RegisterType<UserServiceClient>().As<IUserService>();

            builder
              .Register(c => new ChannelFactory<ICriminalService>(
                new WebHttpBinding(),
                new EndpointAddress("http://localhost:7742/CriminalService.svc")))
              .SingleInstance();

            builder
              .Register(c => c.Resolve<ChannelFactory<ICriminalService>>().CreateChannel())
              .As<ICriminalService>();


            builder.RegisterType<CriminalServiceClient>().As<ICriminalService>();

            builder
              .Register(c => new ChannelFactory<IRoleService>(
                new WebHttpBinding(),
                new EndpointAddress("http://localhost:7742/RoleService.svc")))
              .SingleInstance();

            builder
              .Register(c => c.Resolve<ChannelFactory<IRoleService>>().CreateChannel())
              .As<IRoleService>();


            builder.RegisterType<RoleServiceClient>().As<IRoleService>();

            builder
              .Register(c => new ChannelFactory<INationalityService>(
                new WebHttpBinding(),
                new EndpointAddress("http://localhost:7742/NationalityService.svc")))
              .SingleInstance();

            builder
              .Register(c => c.Resolve<ChannelFactory<INationalityService>>().CreateChannel())
              .As<INationalityService>();


            builder.RegisterType<NationalityServiceClient>().As<INationalityService>();
            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new NCDProfile());
            });
            var mapper = mapperConfiguration.CreateMapper();
            builder.RegisterInstance(mapper).As<IMapper>();
            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
