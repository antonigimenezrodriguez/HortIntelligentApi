using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Dades.Repositoris.Interficies;
using HortIntelligentApi.Domini.Entitats;
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

        public async Task<IList<Vegetal>> GetAll()
        {
            return await VegetalRepository.GetAll();
        }
    }
}
