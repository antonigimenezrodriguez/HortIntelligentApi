using AutoMapper;
using HortIntelligent.Dades.Entitats;
using HortIntelligent.Dades.Repositoris.Interficies;
using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Interficies;

namespace HortIntelligentApi.Domini.Implementacions
{
    public class CampDomini : ICampDomini
    {
        private readonly IMapper mapper;
        private readonly IVegetalDomini vegetalDomini;
        public ICampRepository CampRepository { get; set; }

        public CampDomini(ICampRepository campRepository, IMapper mapper, IVegetalDomini vegetalDomini)
        {
            CampRepository = campRepository;
            this.mapper = mapper;
            this.vegetalDomini = vegetalDomini;
        }

        public async Task<ResultDto<IList<CampDto>>> GetAll()
        {
            ResultDto<IList<CampDto>> result = new ResultDto<IList<CampDto>>();
            try
            {
                var llistat = await CampRepository.GetAllAsync();
                result.StatusCode = StatusCodes.Status200OK;
                result.Data = mapper.Map<List<CampDto>>(llistat);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                result.StatusCode = StatusCodes.Status500InternalServerError;
                result.Errors.Add(ex.Message);
                return await Task.FromResult(result);
            }
        }

        public async Task<ResultDto<CampDto>> Get(int id)
        {
            ResultDto<CampDto> result = new ResultDto<CampDto>();
            try
            {
                var camp = await CampRepository.GetAsync(id);
                if (camp == null)
                {
                    result.StatusCode = StatusCodes.Status404NotFound;
                    result.Errors.Add($"No existeix un camp amb id: {id}");
                    return await Task.FromResult(result);
                }
                else
                {
                    result.StatusCode = StatusCodes.Status200OK;
                    result.Data = mapper.Map<CampDto>(await CampRepository.GetAsync(id));
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
            if (!await CampRepository.ExitsAsync(id))
            {
                resultDto.StatusCode = StatusCodes.Status404NotFound;
                resultDto.Errors.Add($"No s'ha trobat un camp amb ID: {id}");
                return resultDto;
            }
            try
            {
                await CampRepository.DeleteAsync(id);
                await CampRepository.SaveAsync();
                if (await CampRepository.ExitsAsync(id))
                {
                    resultDto.StatusCode = StatusCodes.Status500InternalServerError;
                    resultDto.Errors.Add($"Valor no esperat al borrar camp: {id}");
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

        public async Task<ResultDto<CampDto>> Post(CampDto campDto)
        {
            ResultDto<CampDto> resultDto = await CheckFKs(campDto);
            if (resultDto.Error)
            {
                return await Task.FromResult(resultDto);
            }
            try
            {
                var CampAInsertar = mapper.Map<Camp>(campDto);
                await CampRepository.AddAsync(CampAInsertar);
                await CampRepository.SaveAsync();
                resultDto.Data = mapper.Map<CampDto>(CampAInsertar);
                return await Task.FromResult(resultDto);
            }
            catch (Exception ex)
            {
                resultDto.Errors.Add(ex.Message);
                resultDto.StatusCode = StatusCodes.Status500InternalServerError;
                return await Task.FromResult(resultDto);
            }            
        }

        public async Task<ResultDto<CampDto>> Put(CampDto campDto)
        {
            ResultDto<CampDto> resultDto = await CheckFKs(campDto);
            if (resultDto.Error)
            {
                return await Task.FromResult(resultDto);
            }
            if (!await Exists(campDto.Id))
            {
                resultDto.StatusCode = StatusCodes.Status404NotFound;
                resultDto.Errors.Add($"No existeix el camp {campDto.Id}");
                return await Task.FromResult(resultDto);
            }
            try
            {
                var CampAInsertar = mapper.Map<Camp>(campDto);
                await CampRepository.UpdateAsync(CampAInsertar);
                await CampRepository.SaveAsync();
                resultDto.Data = mapper.Map<CampDto>(CampAInsertar);
            }
            catch (Exception ex)
            {
                resultDto.Errors.Add(ex.Message);
                resultDto.StatusCode = StatusCodes.Status500InternalServerError;
            }
            return await Task.FromResult(resultDto);
        }

        public async Task<bool> Exists(int id)
        {
            return await CampRepository.ExitsAsync(id);
        }

        private async Task<ResultDto<CampDto>> CheckFKs(CampDto campDto)
        {
            ResultDto<CampDto> errorDto = new ResultDto<CampDto>();
            if (campDto.VegetalId.HasValue)
            {
                var existeixVegetal = await vegetalDomini.Exists(campDto.VegetalId.Value);
                if (!existeixVegetal)
                {
                    errorDto.StatusCode = StatusCodes.Status400BadRequest;
                    errorDto.Errors.Add($"Error FK: No Existeix un vegetal amb id: {campDto.VegetalId}");
                }
            }
            return await Task.FromResult(errorDto);
        }
    }
}
