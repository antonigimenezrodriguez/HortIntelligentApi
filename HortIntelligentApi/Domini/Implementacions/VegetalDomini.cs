using AutoMapper;
using HortIntelligent.Dades.Entitats;
using HortIntelligent.Dades.Repositoris.Interficies;
using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Interficies;
using Microsoft.AspNetCore.Mvc;

namespace HortIntelligentApi.Domini.Implementacions
{
    public class VegetalDomini : IVegetalDomini
    {
        public IVegetalRepository VegetalRepository { get; set; }
        private readonly IMapper mapper;

        public VegetalDomini(IVegetalRepository vegetalRepository, IMapper mapper)
        {
            VegetalRepository = vegetalRepository;
            this.mapper = mapper;
        }

        public async Task<IList<VegetalDto>> GetAll()
        {
            return mapper.Map<IList<VegetalDto>>(await VegetalRepository.GetAllAsync());
        }

        public async Task<VegetalDto> Get(int id)
        {
            return mapper.Map<VegetalDto>(await VegetalRepository.GetAsync(id));
        }

        public async Task<bool> Delete(int id)
        {
            var exists = await VegetalRepository.ExitsAsync(id);
            if (!exists)
            {
                return await Task.FromResult(false);
            }
            else
            {
                await VegetalRepository.DeleteAsync(id);
                int saveResult = await VegetalRepository.SaveAsync();
                if (saveResult > 0)
                    return await Task.FromResult(true);
                else
                    return await Task.FromResult(false);

            }
        }

        public async Task<VegetalDto> Post(VegetalDto vegetalDto)
        {
            var vegetal = mapper.Map<Vegetal>(vegetalDto);
            await VegetalRepository.AddAsync(vegetal);
            int saveResult = await VegetalRepository.SaveAsync();
            return await Task.FromResult(mapper.Map<VegetalDto>(vegetal));
        }

        public async Task<VegetalDto> Put(VegetalDto vegetalDto)
        {
            var vegetal = mapper.Map<Vegetal>(vegetalDto);
            await VegetalRepository.UpdateAsync(vegetal);
            int saveResult = await VegetalRepository.SaveAsync();
            return await Task.FromResult(mapper.Map<VegetalDto>(vegetal));
        }
    }
}
