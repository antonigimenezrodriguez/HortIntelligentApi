using NetTopologySuite.Geometries;

namespace HortIntelligentApi.Application.Dtos
{
    public class CampDto
    {
        public int Id { get; set; }
        public string Localitzacio { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Observacions { get; set; }
        public string ImatgeURL { get; set; }

        public int? VegetalId { get; set; }
    }
}
