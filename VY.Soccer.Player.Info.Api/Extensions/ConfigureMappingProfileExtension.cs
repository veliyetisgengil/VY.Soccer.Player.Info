using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VY.Soccer.Player.Info.Api.Extensions
{
    public static class ConfigureMappingProfileExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(i => i.AddProfile(new AutoMappingProfile()));

            IMapper mapper = mappingConfig.CreateMapper();

            service.AddSingleton(mapper);

            return service;
        }
    }

    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Data.Models.Player.Player, Models.Player.PlayerDTO>()
                .ForMember(x=>x.FullName , y=>y.MapFrom(z=>z.FirstName + " " + z.LastName))
               // .ForMember(x=>x.Id,y=>y.MapFrom(z=>z.Id)) otomatik yapılır
                .ReverseMap()
                ;

        }

    }
}
