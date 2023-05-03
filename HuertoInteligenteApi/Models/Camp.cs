using NetTopologySuite.Geometries;

namespace HuertoInteligenteApi.Models
{
    public class Camp
    {
        public int Id { get; set; }
        public string Localitacio { get; set; }
        public Coordinate Coordenades { get; set; }
        public string Observacions { get; set; }
        public string ImatgeURL { get; set; }
    }
}
