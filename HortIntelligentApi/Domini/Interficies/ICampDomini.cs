using HortIntelligentApi.Application.Dtos;

namespace HortIntelligentApi.Domini.Interficies
{
    public interface ICampDomini
    {
        public Task<ResultDto<IList<CampDto>>> GetAll();
        public Task<ResultDto<CampDto>> Get(int id);
        public Task<ResultDto<int>> Delete(int id);
        public Task<ResultDto<CampDto>> Post(CampDto campDto);
        public Task<ResultDto<CampDto>> Put(CampDto campDto);
        public Task<bool> Exists(int id);
    }
}
