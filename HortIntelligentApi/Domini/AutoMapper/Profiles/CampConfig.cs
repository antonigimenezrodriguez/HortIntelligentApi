using AutoMapper;
using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Entitats;

namespace HortIntelligentApi.Domini.AutoMapper.Profiles
{
    public class CampConfig : Profile
    {
        public CampConfig()
        {
            CreateMap<Camp,CampDto>()
                ;
        }
    }
}
