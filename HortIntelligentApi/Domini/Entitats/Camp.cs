using HortIntelligentApi.Application.Dtos;
using NetTopologySuite.Geometries;

namespace HortIntelligentApi.Domini.Entitats
{
    public class Camp
    {
        public int Id { get; set; }
        public string Localitzacio { get; set; }
        public Point Coordenades { get; set; }
        public string Observacions { get; set; }
        public string ImatgeURL { get; set; }

        //FK
        public int? VegetalId { get; set; }
        public Vegetal Vegetal { get; set; }

        public Camp() { }
        public Camp(int id, string localitzacio, Point coordenades, string observacions, string imatgeURL, int? vegetalId)
        {
            Id = id;
            Localitzacio = localitzacio;
            Coordenades = coordenades;
            Observacions = observacions;
            ImatgeURL = imatgeURL;
            VegetalId = vegetalId;
        }

        public Camp ActualitzarCamp(CampDto campDto)
        {
            this.Id = campDto.Id;
            this.Localitzacio = campDto.Localitzacio;
            this.Coordenades = campDto.Coordenades;
            this.Observacions = campDto.Observacions;
            this.ImatgeURL = campDto.ImatgeURL;
            this.VegetalId = campDto.VegetalId;

            return this;
        }
    }
}
