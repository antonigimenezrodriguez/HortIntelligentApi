using AutoMapper;
using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Entitats;

namespace HortIntelligentApi.Domini.AutoMapper.Profiles
{
    public class VegetalProfile : Profile
    {
        public VegetalProfile()
        {
            CreateMap<Vegetal, VegetalDto>()
                ;
        }
    }
}
