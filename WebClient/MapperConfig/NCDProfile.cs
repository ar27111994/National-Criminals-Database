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
    public class NCDProfile:Profile
    {
        public NCDProfile()
        {
            CreateMap<UserDTO, User>(MemberList.None);
            CreateMap<RoleDTO, Role>(MemberList.None);
            CreateMap<CriminalDTO, Criminal>(MemberList.None);
            CreateMap<NationalityDTO, Nationality>(MemberList.None);
            CreateMap<User, UserDTO>(MemberList.None);
            CreateMap<Role, RoleDTO>(MemberList.None);
            CreateMap<Criminal, CriminalDTO>(MemberList.None);
            CreateMap<Nationality, NationalityDTO>(MemberList.None);
        }
    }
}
