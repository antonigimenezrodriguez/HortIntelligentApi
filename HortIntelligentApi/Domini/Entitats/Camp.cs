using HortIntelligentApi.Application.Dtos;
using NetTopologySuite.Geometries;

namespace HortIntelligentApi.Domini.Entitats
{
    public class Camp
    {
        public int Id { get; set; }
        public string Localitzacio { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Observacions { get; set; }
        public string ImatgeURL { get; set; }

        //FK
        public int? VegetalId { get; set; }
        public Vegetal Vegetal { get; set; }

        public Camp() { }
        public Camp(int id, string localitzacio, double latitud, double longitud, string observacions, string imatgeURL, int? vegetalId)
        {
            Id = id;
            Localitzacio = localitzacio;
            Latitud = latitud;
            Longitud = longitud;
            Observacions = observacions;
            ImatgeURL = imatgeURL;
            VegetalId = vegetalId;
        }

        public Camp ActualitzarCamp(CampDto campDto)
        {
            this.Id = campDto.Id;
            this.Localitzacio = campDto.Localitzacio;
            this.Latitud = campDto.Latitud;
            this.Longitud = campDto.Longitud;
            this.Observacions = campDto.Observacions;
            this.ImatgeURL = campDto.ImatgeURL;
            this.VegetalId = campDto.VegetalId;

            return this;
        }
    }
}
