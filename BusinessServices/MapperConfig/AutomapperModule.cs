﻿using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.MapperConfig
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var profiles = context.Resolve<IEnumerable<Profile>>();

                var config = new MapperConfiguration(x =>
                {
                    // Load in all our AutoMapper profiles that have been registered
                    x.AddProfile(new DtoToEntityProfile());
                    x.AddProfile(new EntityToDtoProfile());
                });

                return config;
            }).SingleInstance() // We only need one instance
                .AutoActivate() // Create it on ContainerBuilder.Build()
                .AsSelf(); // Bind it to its own type

            // HACK: IComponentContext needs to be resolved again as 'tempContext' is only temporary. See http://stackoverflow.com/a/5386634/718053 
            builder.Register(tempContext =>
            {
                var ctx = tempContext.Resolve<IComponentContext>();
                var config = ctx.Resolve<MapperConfiguration>();

                // Create our mapper using our configuration above
                return config.CreateMapper(t => ctx.Resolve(t));
            }).As<IMapper>(); // Bind it to the IMapper interface

            base.Load(builder);
        }
    }
}
