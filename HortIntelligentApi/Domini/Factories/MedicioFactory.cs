using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Entitats;

namespace HortIntelligentApi.Domini.Factories
{
    public class MedicioFactory
    {
        internal static Medicio CrearMedicio(MedicioDto medicioDto)
        {
            return new Medicio(
                0,
                medicioDto.Valor,
                medicioDto.DataHora,
                medicioDto.SensorId,
                medicioDto.VegetalId,
                medicioDto.CampId
                );
        }
    }
}
