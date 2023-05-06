using AutoMapper;
using HortIntelligent.Dades.Entitats;
using HortIntelligentApi.Application.Dtos;

namespace HortIntelligentApi.Domini.AutoMapper.Profiles
{
    public class SensorProfile : Profile
    {
        public SensorProfile()
        {
            CreateMap<Sensor, SensorDto>()
               ;
            CreateMap<SensorDto, Sensor>()
                ;
        }
    }
}
