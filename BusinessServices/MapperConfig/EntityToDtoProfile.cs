using AutoMapper;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebClientContracts;

namespace BusinessServices.MapperConfig
{
    class EntityToDtoProfile:Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<User, UserDTO>().IgnoreAllNonExisting();
            CreateMap<Role, RoleDTO>().IgnoreAllNonExisting();
            CreateMap<Criminal, CriminalDTO>().IgnoreAllNonExisting();
            CreateMap<Nationality, NationalityDTO>().IgnoreAllNonExisting();
        }
    }
}
