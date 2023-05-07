using AutoMapper;
using HortIntelligent.Dades.Entitats;
using HortIntelligent.Dades.Repositoris.Interficies;
using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Interficies;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace HortIntelligentApi.Domini.Implementacions
{
    public class CampDomini : ICampDomini
    {
        private readonly IMapper mapper;
        public ICampRepository CampRepository { get; set; }

        public CampDomini(ICampRepository campRepository, IMapper mapper)
        {
            CampRepository = campRepository;
            this.mapper = mapper;
        }

        public async Task<IList<CampDto>> GetAll()
        {
            return mapper.Map<List<CampDto>>(await CampRepository.GetAllAsync());
        }

        public async Task<CampDto> Get(int id)
        {
            return mapper.Map<CampDto>(await CampRepository.GetAsync(id));
        }

        public async Task<bool> Delete(int id)
        {
            if (!await CampRepository.ExitsAsync(id))
                return await Task.FromResult(false);
            await CampRepository.DeleteAsync(id);
            await CampRepository.SaveAsync();
            if (await CampRepository.ExitsAsync(id))
                return await Task.FromResult(false);
            else
                return await Task.FromResult(true);
        }

        public async Task<CampDto> Post(CampDto campDto)
        {
            var CampAInsertar = mapper.Map<Camp>(campDto);
            await CampRepository.AddAsync(CampAInsertar);
            await CampRepository.SaveAsync();
            return mapper.Map<CampDto>(CampAInsertar);
        }

        public async Task<CampDto> Put(CampDto campDto)
        {
            var campAModificar = mapper.Map<Camp>(campDto);
            await CampRepository.UpdateAsync(campAModificar);
            await CampRepository.SaveAsync();
            return mapper.Map<CampDto>(campAModificar);
        }

        public async Task<bool> Exists(int id)
        {
            return await CampRepository.ExitsAsync(id);
        }
    }
}
