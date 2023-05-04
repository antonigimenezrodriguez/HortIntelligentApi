using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Entitats;

namespace HortIntelligentApi.Domini.Interficies
{
    public interface IVegetalDomini
    {
        public Task<IList<VegetalDto>> GetAll();
        public Task<VegetalDto> Get(int id);
        public Task<int> Delete(int id);
    }
}
