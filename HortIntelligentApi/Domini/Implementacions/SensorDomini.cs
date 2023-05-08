using AutoMapper;
using HortIntelligent.Dades.Entitats;
using HortIntelligent.Dades.Repositoris.Implementacions;
using HortIntelligent.Dades.Repositoris.Interficies;
using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Interficies;

namespace HortIntelligentApi.Domini.Implementacions
{
    public class SensorDomini : ISensorDomini
    {
        public ISensorRepository SensorRepository { get; set; }
        private readonly IMapper mapper;

        public SensorDomini(ISensorRepository sensorRepository, IMapper mapper)
        {
            SensorRepository = sensorRepository;
            this.mapper = mapper;
        }

        public async Task<ResultDto<IList<SensorDto>>> GetAll()
        {
            ResultDto<IList<SensorDto>> result = new ResultDto<IList<SensorDto>>();
            try
            {
                var llistat = await SensorRepository.GetAllAsync();
                result.StatusCode = StatusCodes.Status200OK;
                result.Data = mapper.Map<List<SensorDto>>(llistat);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                result.StatusCode = StatusCodes.Status500InternalServerError;
                result.Errors.Add(ex.Message);
                return await Task.FromResult(result);
            }
        }

        public async Task<ResultDto<SensorDto>> Get(int id)
        {
            ResultDto<SensorDto> result = new ResultDto<SensorDto>();
            try
            {
                var camp = await SensorRepository.GetAsync(id);
                if (camp == null)
                {
                    result.StatusCode = StatusCodes.Status404NotFound;
                    result.Errors.Add($"No existeix un sensor amb id: {id}");
                    return await Task.FromResult(result);
                }
                else
                {
                    result.StatusCode = StatusCodes.Status200OK;
                    result.Data = mapper.Map<SensorDto>(await SensorRepository.GetAsync(id));
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
            if (!await SensorRepository.ExitsAsync(id))
            {
                resultDto.StatusCode = StatusCodes.Status404NotFound;
                resultDto.Errors.Add($"No s'ha trobat un sensor amb ID: {id}");
                return resultDto;
            }
            try
            {
                await SensorRepository.DeleteAsync(id);
                await SensorRepository.SaveAsync();
                if (await SensorRepository.ExitsAsync(id))
                {
                    resultDto.StatusCode = StatusCodes.Status500InternalServerError;
                    resultDto.Errors.Add($"Valor no esperat al borrar sensor: {id}");
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

        public async Task<ResultDto<SensorDto>> Post(SensorDto sensorDto)
        {
            ResultDto<SensorDto> resultDto = await CheckFKs(sensorDto);
            if (resultDto.Error)
            {
                return await Task.FromResult(resultDto);
            }
            try
            {
                var CampAInsertar = mapper.Map<Sensor>(sensorDto);
                await SensorRepository.AddAsync(CampAInsertar);
                await SensorRepository.SaveAsync();
                resultDto.Data = mapper.Map<SensorDto>(CampAInsertar);
                return await Task.FromResult(resultDto);
            }
            catch (Exception ex)
            {
                resultDto.Errors.Add(ex.Message);
                resultDto.StatusCode = StatusCodes.Status500InternalServerError;
                return await Task.FromResult(resultDto);
            }
        }

        public async Task<ResultDto<SensorDto>> Put(SensorDto sensorDto)
        {
            ResultDto<SensorDto> resultDto = await CheckFKs(sensorDto);
            if (resultDto.Error)
            {
                return await Task.FromResult(resultDto);
            }
            if (!await Exists(sensorDto.Id))
            {
                resultDto.StatusCode = StatusCodes.Status404NotFound;
                resultDto.Errors.Add($"No existeix el camp {sensorDto.Id}");
                return await Task.FromResult(resultDto);
            }
            try
            {
                var SensorAInsertar = mapper.Map<Sensor>(sensorDto);
                await SensorRepository.UpdateAsync(SensorAInsertar);
                await SensorRepository.SaveAsync();
                resultDto.Data = mapper.Map<SensorDto>(SensorAInsertar);
            }
            catch (Exception ex)
            {
                resultDto.Errors.Add(ex.Message);
                resultDto.StatusCode = StatusCodes.Status500InternalServerError;
            }
            return await Task.FromResult(resultDto);
        }

        public async Task<bool> Exists(int sensorId)
        {
            return await SensorRepository.ExitsAsync(sensorId);
        }

        private async Task<ResultDto<SensorDto>> CheckFKs(SensorDto sensorDto)
        {
            return await Task.FromResult(new ResultDto<SensorDto>());
        }
    }
}
