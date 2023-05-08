using HortIntelligentApi.Application.Dtos;

namespace HortIntelligentApi.Domini.Interficies
{
    public interface IVegetalDomini
    {
        public Task<ResultDto<IList<VegetalDto>>> GetAll();
        public Task<ResultDto<VegetalDto>> Get(int id);
        public Task<ResultDto<int>> Delete(int id);
        public Task<ResultDto<VegetalDto>> Post(VegetalDto vegetal);
        public Task<ResultDto<VegetalDto>> Put(VegetalDto vegetal);
        public Task<bool> Exists(int vegetalId);
    }
}
