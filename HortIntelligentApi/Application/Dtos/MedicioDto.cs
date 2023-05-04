using HortIntelligentApi.Domini.Entitats;

namespace HortIntelligentApi.Application.Dtos
{
    public class MedicioDto
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }
        public int SensorId { get; set; }
        public int VegetalId { get; set; }
        public int CampId { get; set; }
    }
}
