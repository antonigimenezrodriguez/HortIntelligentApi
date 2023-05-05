using AutoMapper;
using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Entitats;

namespace HortIntelligentApi.Domini.AutoMapper.Profiles
{
    public class MedicioConfig : Profile
    {
        public MedicioConfig()
        {
            CreateMap<Medicio, MedicioDto>()
                ;
        }
    }
}
