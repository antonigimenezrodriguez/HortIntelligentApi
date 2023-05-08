using AutoMapper;
using HortIntelligent.Dades.Entitats;
using HortIntelligent.Dades.Repositoris.Implementacions;
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

        public async Task<ResultDto<IList<VegetalDto>>> GetAll()
        {
            ResultDto<IList<VegetalDto>> result = new ResultDto<IList<VegetalDto>>();
            try
            {
                var llistat = await VegetalRepository.GetAllAsync();
                result.StatusCode = StatusCodes.Status200OK;
                result.Data = mapper.Map<List<VegetalDto>>(llistat);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                result.StatusCode = StatusCodes.Status500InternalServerError;
                result.Errors.Add(ex.Message);
                return await Task.FromResult(result);
            }
        }

        public async Task<ResultDto<VegetalDto>> Get(int id)
        {
            ResultDto<VegetalDto> result = new ResultDto<VegetalDto>();
            try
            {
                var vegetal = await VegetalRepository.GetAsync(id);
                if (vegetal == null)
                {
                    result.StatusCode = StatusCodes.Status404NotFound;
                    result.Errors.Add($"No existeix un vegetal amb id: {id}");
                    return await Task.FromResult(result);
                }
                else
                {
                    result.StatusCode = StatusCodes.Status200OK;
                    result.Data = mapper.Map<VegetalDto>(await VegetalRepository.GetAsync(id));
                    return await Task.FromResult(result);
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = StatusCodes.Status500InternalServerError;
                result.Errors.Add(ex.Message);
                return await Task.FromResult(result);
            }
        }

        public async Task<ResultDto<int>> Delete(int id)
        {
            ResultDto<int> resultDto = new ResultDto<int>();
            if (!await VegetalRepository.ExitsAsync(id))
            {
                resultDto.StatusCode = StatusCodes.Status404NotFound;
                resultDto.Errors.Add($"No s'ha trobat un vegetal amb ID: {id}");
                return resultDto;
            }
            try
            {
                await VegetalRepository.DeleteAsync(id);
                await VegetalRepository.SaveAsync();
                if (await VegetalRepository.ExitsAsync(id))
                {
                    resultDto.StatusCode = StatusCodes.Status500InternalServerError;
                    resultDto.Errors.Add($"Valor no esperat al borrar vegetal: {id}");
                    return await Task.FromResult(resultDto);
                }
                else
                {
                    resultDto.Data = id;
                    resultDto.StatusCode = StatusCodes.Status200OK;
                    return await Task.FromResult(resultDto);
                }
            }
            catch (Exception ex)
            {
                resultDto.Errors.Add(ex.Message);
                resultDto.StatusCode = StatusCodes.Status500InternalServerError;
                return await Task.FromResult(resultDto);
            }
        }

        public async Task<ResultDto<VegetalDto>> Post(VegetalDto vegetalDto)
        {
            ResultDto<VegetalDto> resultDto = await CheckFKs(vegetalDto);
            if (resultDto.Error)
            {
                return await Task.FromResult(resultDto);
            }
            try
            {
                var VegetalAInsertar = mapper.Map<Vegetal>(vegetalDto);
                await VegetalRepository.AddAsync(VegetalAInsertar);
                await VegetalRepository.SaveAsync();
                resultDto.Data = mapper.Map<VegetalDto>(VegetalAInsertar);
                return await Task.FromResult(resultDto);
            }
            catch (Exception ex)
            {
                resultDto.Errors.Add(ex.Message);
                resultDto.StatusCode = StatusCodes.Status500InternalServerError;
                return await Task.FromResult(resultDto);
            }
        }

        public async Task<ResultDto<VegetalDto>> Put(VegetalDto vegetalDto)
        {
            ResultDto<VegetalDto> resultDto = await CheckFKs(vegetalDto);
            if (resultDto.Error)
            {
                return await Task.FromResult(resultDto);
            }
            if (!await Exists(vegetalDto.Id))
            {
                resultDto.StatusCode = StatusCodes.Status404NotFound;
                resultDto.Errors.Add($"No existeix el vegetal {vegetalDto.Id}");
                return await Task.FromResult(resultDto);
            }
            try
            {
                var VegetalAInsertar = mapper.Map<Vegetal>(vegetalDto);
                await VegetalRepository.UpdateAsync(VegetalAInsertar);
                await VegetalRepository.SaveAsync();
                resultDto.Data = mapper.Map<VegetalDto>(VegetalAInsertar);
            }
            catch (Exception ex)
            {
                resultDto.Errors.Add(ex.Message);
                resultDto.StatusCode = StatusCodes.Status500InternalServerError;
            }
            return await Task.FromResult(resultDto);
        }

        public async Task<bool> Exists(int vegetalId)
        {
            return await VegetalRepository.ExitsAsync(vegetalId);
        }

        private async Task<ResultDto<VegetalDto>> CheckFKs(VegetalDto vegetalDto)
        {
            return await Task.FromResult(new ResultDto<VegetalDto>());
        }
    }
}
