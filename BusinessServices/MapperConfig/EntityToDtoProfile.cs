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
    public class EntityToDtoProfile:Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<User, UserDTO>(MemberList.None);
            CreateMap<Role, RoleDTO>(MemberList.None);
            CreateMap<Criminal, CriminalDTO>(MemberList.None);
            CreateMap<Nationality, NationalityDTO>(MemberList.None);
        }
    }
}
