using HortIntelligentApi.Domini.Entitats;

namespace HortIntelligentApi.Application.Dtos
{
    public class SensorDto
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Model { get; set; }
        public string Descripcio { get; set; }
        public EnumTipusSensor Tipus { get; set; }
        public string ImatgeURL { get; set; }
        public HashSet<Medicio> Medicions { get; set; }
    }
}
