using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Entitats;

namespace HortIntelligentApi.Domini.Interficies
{
    public interface IVegetalDomini
    {
        public Task<IList<Vegetal>> GetAll();
    }
}
