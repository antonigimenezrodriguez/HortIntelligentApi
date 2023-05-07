using AutoMapper;
using HortIntelligent.Dades.Entitats;
using HortIntelligentApi.Application.Dtos;

namespace HortIntelligentApi.Domini.AutoMapper.Profiles
{
    public class MedicioConfig : Profile
    {
        public MedicioConfig()
        {
            CreateMap<Medicio, MedicioDto>()
                ;
            CreateMap<MedicioDto, Medicio>()
                ;
        }
    }
}
