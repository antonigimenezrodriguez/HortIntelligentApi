using HortIntelligentApi.Application.Dtos;

namespace HortIntelligentApi.Domini.Interficies
{
    public interface ICampDomini
    {
        public Task<IList<CampDto>> GetAll();
        public Task<CampDto> Get(int id);
        public Task<bool> Delete(int id);
        public Task<CampDto> Post(CampDto campDto);
        public Task<CampDto> Put(CampDto campDto);
        public Task<bool> Exists(int id);
    }
}
