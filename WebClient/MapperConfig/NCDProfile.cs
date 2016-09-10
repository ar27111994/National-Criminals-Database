using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebClientContracts;
using WebUIClient.ViewModels;

namespace WebUIClient.MapperConfig
{
    internal class NCDProfile:Profile
    {
        public NCDProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<RoleDTO, Role>();
            CreateMap<CriminalDTO, Criminal>();
            CreateMap<NationalityDTO, Nationality>();
            CreateMap<User, UserDTO>();
            CreateMap<Role, RoleDTO>();
            CreateMap<Criminal, CriminalDTO>();
            CreateMap<Nationality, NationalityDTO>();
        }
    }
}
