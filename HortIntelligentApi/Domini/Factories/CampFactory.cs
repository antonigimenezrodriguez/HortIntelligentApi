using HortIntelligentApi.Domini.Entitats;
using HortIntelligentApi.Domini.Implementacions;

namespace HortIntelligentApi.Domini.Factories
{
    public static class CampFactory
    {
        public static Camp CrearCamp(CampDomini campDomini)
        {
            return new Camp();
        }
    }
}
