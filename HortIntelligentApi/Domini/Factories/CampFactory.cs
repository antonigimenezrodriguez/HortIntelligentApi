using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Entitats;

namespace HortIntelligentApi.Domini.Factories
{
    public static class CampFactory
    {
        public static Camp CrearCamp(CampDto camp)
        {
            return new Camp(
                0,
                camp.Localitzacio,
                camp.Latitud,
                camp.Longitud,
                camp.Observacions,
                camp.ImatgeURL,
                camp.VegetalId
                );
        }
    }
}
