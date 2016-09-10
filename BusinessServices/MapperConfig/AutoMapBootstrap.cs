using AutoMapper;
using Persistence;
using WebClientContracts;

namespace BusinessServices.MapperConfig
{
    internal class AutoMapBootstrap
    {
        public static void InitializeMap()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.DisableConstructorMapping();

                cfg.AddProfile(new DtoToEntityProfile());
                cfg.AddProfile(new EntityToDtoProfile());
            });

        }

    }
}