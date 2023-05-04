using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Entitats;

namespace HortIntelligentApi.Domini.Factories
{
    public class VegetalFactory
    {
        public static Vegetal CrearVegetal(VegetalDto vegetalDto)
        {
            return new Vegetal(
                0, 
                vegetalDto.Nom, 
                vegetalDto.Descripcio, 
                vegetalDto.ImatgeURL, 
                vegetalDto.TemperaturaMaxima,
                vegetalDto.TemperaturaMinima,
                vegetalDto.TemperaturaOptima,
                vegetalDto.HumitatMaxima,
                vegetalDto.HumitatMinima,
                vegetalDto.HumitatOptima
                );
        }
    }
}
