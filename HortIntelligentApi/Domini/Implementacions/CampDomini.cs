using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Dades.Repositoris.Interficies;
using HortIntelligentApi.Domini.Interficies;
using NetTopologySuite.Geometries;

namespace HortIntelligentApi.Domini.Implementacions
{
    public class CampDomini : ICampDomini
    {
        public ICampRepository CampRepository { get; set; }

        public CampDomini(ICampRepository campRepository)
        {
            CampRepository = campRepository;
        }

        public async Task<IList<CampDto>> GetAll()
        {
            return await CampRepository.GetAll();
        }

        public async Task<CampDto> Get(int id)
        {
            return await CampRepository.Get(id);
        }

        public async Task<bool> Delete(int id)
        {
            return await CampRepository.Delete(id);
        }

        public async Task<CampDto> Post(CampDto campDto)
        {
            return await CampRepository.Post(campDto);
        }

        public async Task<CampDto> Put(CampDto campDto)
        {
            return await CampRepository.Put(campDto);
        }
    }
}
