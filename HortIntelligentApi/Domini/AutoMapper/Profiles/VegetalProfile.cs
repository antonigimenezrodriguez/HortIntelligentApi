using AutoMapper;
using HortIntelligent.Dades.Entitats;
using HortIntelligentApi.Application.Dtos;

namespace HortIntelligentApi.Domini.AutoMapper.Profiles
{
    public class VegetalProfile : Profile
    {
        public VegetalProfile()
        {
            CreateMap<Vegetal, VegetalDto>()
                ;
            CreateMap<VegetalDto, Vegetal>()
                ;
        }
    }
}
