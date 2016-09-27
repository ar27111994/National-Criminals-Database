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
    internal class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<UserDTO, User>(MemberList.None);
            CreateMap<RoleDTO, Role>(MemberList.None);
            CreateMap<CriminalDTO, Criminal>(MemberList.None);
            CreateMap<NationalityDTO, Nationality>(MemberList.None);
        }
    }
}
