using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Entitats;

namespace HortIntelligentApi.Dades.Repositoris.Interficies
{
    public interface IVegetalRepository
    {
        public Task<IList<VegetalDto>> GetAll();
        public Task<VegetalDto> Get(int id);
        public Task<bool> Delete(int id);
        public Task<VegetalDto> Post(VegetalDto vegetal);
    }
}
