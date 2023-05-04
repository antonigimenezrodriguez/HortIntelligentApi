using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Entitats;

namespace HortIntelligentApi.Domini.Interficies
{
    public interface IVegetalDomini
    {
        public Task<IList<VegetalDto>> GetAll();
        public Task<VegetalDto> Get(int id);
        public Task<bool> Delete(int id);
        public Task<VegetalDto> Post(VegetalDto vegetal);
        public Task<VegetalDto> Put(VegetalDto vegetal);
    }
}
