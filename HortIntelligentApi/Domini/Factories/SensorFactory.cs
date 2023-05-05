using HortIntelligentApi.Application.Dtos;
using HortIntelligentApi.Domini.Entitats;

namespace HortIntelligentApi.Domini.Factories
{
    public static class SensorFactory
    {
        public static Sensor CrearSensor(SensorDto sensorDto)
        {
            return new Sensor(
                0,
                sensorDto.Nom,
                sensorDto.Model,
                sensorDto.Descripcio,
                sensorDto.Tipus,
                sensorDto.ImatgeURL
                );
        }
    }
}
