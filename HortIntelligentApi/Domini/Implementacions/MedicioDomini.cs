using AutoMapper;
using HortIntelligent.Dades.Entitats;
using HortIntelligent.Dades.Repositoris.Implementacions;
using HortIntelligent.Dades.Repositoris.Interficies;
using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Interficies;

namespace HortIntelligentApi.Domini.Implementacions
{
    public class MedicioDomini : IMedicioDomini
    {
        public IMedicioRepository MedicioRepository { get; set; }
        public IVegetalDomini VegetalDomini { get; set; }
        public ISensorDomini SensorDomini { get; set; }
        public ICampDomini CampDomini { get; set; }
        private readonly IMapper mapper;


        public MedicioDomini(IMedicioRepository medicioRepository, IMapper mapper, ICampDomini campDomini, IVegetalDomini vegetalDomini, ISensorDomini sensorDomini)
        {
            MedicioRepository = medicioRepository;
            this.mapper = mapper;
            CampDomini = campDomini;
            VegetalDomini = vegetalDomini;
            SensorDomini = sensorDomini;
        }

        public async Task<ResultDto<IList<MedicioDto>>> GetAll()
        {
            ResultDto<IList<MedicioDto>> result = new ResultDto<IList<MedicioDto>>();
            try
            {
                var llistat = await MedicioRepository.GetAllAsync();
                result.StatusCode = StatusCodes.Status200OK;
                result.Data = mapper.Map<List<MedicioDto>>(llistat);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                result.StatusCode = StatusCodes.Status500InternalServerError;
                result.Errors.Add(ex.Message);
                return await Task.FromResult(result);
            }
        }

        public async Task<ResultDto<MedicioDto>> Get(int id)
        {
            ResultDto<MedicioDto> result = new ResultDto<MedicioDto>();
            try
            {
                var medicio = await MedicioRepository.GetAsync(id);
                if (medicio == null)
                {
                    result.StatusCode = StatusCodes.Status404NotFound;
                    result.Errors.Add($"No existeix una medició amb id: {id}");
                    return await Task.FromResult(result);
                }
                else
                {
                    result.StatusCode = StatusCodes.Status200OK;
                    result.Data = mapper.Map<MedicioDto>(await MedicioRepository.GetAsync(id));
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

        public async Task<ResultDto<IList<MedicioDto>>> GetByCampId(int campId)
        {
            ResultDto<IList<MedicioDto>> result = new ResultDto<IList<MedicioDto>>();
            var existeixCamp = await ExisteixCamp(campId);
            if (!existeixCamp)
            {
                result.StatusCode = StatusCodes.Status400BadRequest;
                result.Errors.Add($"No Existeix un camp amb id: {campId}");
                return await Task.FromResult(result);
            }
            try
            {
                var llistat = await MedicioRepository.GetByCampIdAsync(campId);
                result.StatusCode = StatusCodes.Status200OK;
                result.Data = mapper.Map<List<MedicioDto>>(llistat);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                result.StatusCode = StatusCodes.Status500InternalServerError;
                result.Errors.Add(ex.Message);
                return await Task.FromResult(result);
            }
        }

        public async Task<ResultDto<IList<MedicioDto>>> GetByVegetalId(int vegetalId)
        {
            ResultDto<IList<MedicioDto>> result = new ResultDto<IList<MedicioDto>>();
            var existeixCamp = await ExisteixVegetal(vegetalId);
            if (!existeixCamp)
            {
                result.StatusCode = StatusCodes.Status400BadRequest;
                result.Errors.Add($"No Existeix un vegetal amb id: {vegetalId}");
                return await Task.FromResult(result);
            }
            try
            {
                var llistat = await MedicioRepository.GetByVegetalIdAsync(vegetalId);
                result.StatusCode = StatusCodes.Status200OK;
                result.Data = mapper.Map<List<MedicioDto>>(llistat);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                result.StatusCode = StatusCodes.Status500InternalServerError;
                result.Errors.Add(ex.Message);
                return await Task.FromResult(result);
            }
        }

        public async Task<ResultDto<IList<MedicioDto>>> GetBySensorId(int sensorId)
        {
            ResultDto<IList<MedicioDto>> result = new ResultDto<IList<MedicioDto>>();
            var existeixCamp = await ExisteixSensor(sensorId);
            if (!existeixCamp)
            {
                result.StatusCode = StatusCodes.Status400BadRequest;
                result.Errors.Add($"No Existeix un sensor amb id: {sensorId}");
                return await Task.FromResult(result);
            }
            try
            {
                var llistat = await MedicioRepository.GetBySensorIdAsync(sensorId);
                result.StatusCode = StatusCodes.Status200OK;
                result.Data = mapper.Map<List<MedicioDto>>(llistat);
                return await Task.FromResult(result);
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
            if (!await MedicioRepository.ExitsAsync(id))
            {
                resultDto.StatusCode = StatusCodes.Status404NotFound;
                resultDto.Errors.Add($"No s'ha trobat una medició amb ID: {id}");
                return resultDto;
            }
            try
            {
                await MedicioRepository.DeleteAsync(id);
                await MedicioRepository.SaveAsync();
                if (await MedicioRepository.ExitsAsync(id))
                {
                    resultDto.StatusCode = StatusCodes.Status500InternalServerError;
                    resultDto.Errors.Add($"Valor no esperat al borrar medició: {id}");
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

        public async Task<ResultDto<MedicioDto>> Post(MedicioDto medicioDto)
        {
            ResultDto<MedicioDto> resultDto = await CheckFKs(medicioDto);
            if (resultDto.Error)
            {
                return await Task.FromResult(resultDto);
            }
            try
            {
                var MedicioAinsertar = mapper.Map<Medicio>(medicioDto);
                await MedicioRepository.AddAsync(MedicioAinsertar);
                await MedicioRepository.SaveAsync();
                resultDto.Data = mapper.Map<MedicioDto>(MedicioAinsertar);
                return await Task.FromResult(resultDto);
            }
            catch (Exception ex)
            {
                resultDto.Errors.Add(ex.Message);
                resultDto.StatusCode = StatusCodes.Status500InternalServerError;
                return await Task.FromResult(resultDto);
            }
        }

        public async Task<bool> ExisteixCamp(int campId)
        {
            return await CampDomini.Exists(campId);
        }

        public async Task<bool> ExisteixVegetal(int vegetalId)
        {
            return await VegetalDomini.Exists(vegetalId);
        }

        public async Task<bool> ExisteixSensor(int sensorId)
        {
            return await SensorDomini.Exists(sensorId);
        }

        public async Task<bool> Exists(int id)
        {
            return await MedicioRepository.ExitsAsync(id);
        }

        private async Task<ResultDto<MedicioDto>> CheckFKs(MedicioDto medicioDto)
        {
            ResultDto<MedicioDto> errorDto = new ResultDto<MedicioDto>();

            var existeixVegetal = await ExisteixVegetal(medicioDto.VegetalId);
            if (!existeixVegetal)
            {
                errorDto.StatusCode = StatusCodes.Status400BadRequest;
                errorDto.Errors.Add($"Error FK: No Existeix un vegetal amb id: {medicioDto.VegetalId}");
            }
            var existeixCamp = await ExisteixCamp(medicioDto.CampId);
            if (!existeixCamp)
            {
                errorDto.StatusCode = StatusCodes.Status400BadRequest;
                errorDto.Errors.Add($"Error FK: No Existeix un camp amb id: {medicioDto.CampId}");
            }
            var existeixSensor = await ExisteixSensor(medicioDto.SensorId);
            if (!existeixSensor)
            {
                errorDto.StatusCode = StatusCodes.Status400BadRequest;
                errorDto.Errors.Add($"Error FK: No Existeix un sensor amb id: {medicioDto.SensorId}");
            }
            return await Task.FromResult(errorDto);
        }
    }
}
