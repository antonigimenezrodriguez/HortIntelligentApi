using AutoMapper;
using HortIntelligent.Dades.Entitats;
using HortIntelligentApi.Application.Dtos;

namespace HortIntelligentApi.Domini.AutoMapper.Profiles
{
    public class CampConfig : Profile
    {
        public CampConfig()
        {
            CreateMap<Camp,CampDto>()
                ;
            CreateMap<CampDto, Camp>()
                ;
        }
    }
}
