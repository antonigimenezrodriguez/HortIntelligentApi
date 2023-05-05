using AutoMapper;
using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Entitats;

namespace HortIntelligentApi.Domini.AutoMapper.Profiles
{
    public class SensorProfile : Profile
    {
        public SensorProfile()
        {
            CreateMap<Sensor, SensorDto>()
               ;
        }
    }
}
