using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Dades.Repositoris.Interficies;
using HortIntelligentApi.Domini.Interficies;

namespace HortIntelligentApi.Domini.Implementacions
{
    public class VegetalDomini : IVegetalDomini
    {
        public IVegetalRepository VegetalRepository { get; set; }

        public VegetalDomini(IVegetalRepository vegetalRepository)
        {
            VegetalRepository = vegetalRepository;
        }

        public async Task<IList<VegetalDto>> GetAll()
        {
            return await VegetalRepository.GetAll();
        }

        public async Task<VegetalDto> Get(int id)
        {
            return await VegetalRepository.Get(id);
        }

        public async Task<bool> Delete(int id)
        {
            return await VegetalRepository.Delete(id);
        }

        public async Task<VegetalDto> Post(VegetalDto vegetal)
        {
            return await VegetalRepository.Post(vegetal);
        }

        public async Task<VegetalDto> Put(VegetalDto vegetal)
        {
            return await VegetalRepository.Put(vegetal);
        }
    }
}
