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
            CreateMap<UserDTO, User>().ForAllMembers(opt => opt.Condition(srs => srs != null));
            CreateMap<RoleDTO, Role>().ForAllMembers(opt => opt.Condition(srs => srs != null));
            CreateMap<CriminalDTO, Criminal>().ForAllMembers(opt => opt.Condition(srs => srs != null));
            CreateMap<NationalityDTO, Nationality>().ForAllMembers(opt => opt.Condition(srs => srs != null));
        }
    }
    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);
            var existingMaps = Mapper.Instance.ConfigurationProvider.GetAllTypeMaps().First(x => x.SourceType.Equals(sourceType) && x.DestinationType.Equals(destinationType));
            foreach (var property in existingMaps.GetUnmappedPropertyNames())
            {
                expression.ForMember(property, opt => opt.Ignore());
            }
            return expression;
        }
    }
}
