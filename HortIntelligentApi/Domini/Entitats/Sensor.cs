using HortIntelligentApi.Application.Dtos;

namespace HortIntelligentApi.Domini.Entitats
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Model { get; set; }
        public string Descripcio { get; set; }
        public EnumTipusSensor Tipus { get; set; }
        public string ImatgeURL { get; set; }

        //Navegació
        public HashSet<Medicio> Medicions { get; set; }

        public Sensor() { }
        public Sensor(int id, string nom, string model, string descripcio, EnumTipusSensor tipus, string imatgeURL, HashSet<Medicio> medicions)
        {
            Id = id;
            Nom = nom;
            Model = model;
            Descripcio = descripcio;
            Tipus = tipus;
            ImatgeURL = imatgeURL;
            Medicions = medicions;
        }

        public Sensor Actualitzar(SensorDto sensorDto)
        {
            this.Id = sensorDto.Id;
            this.Nom = sensorDto.Nom;
            this.Model = sensorDto.Model;
            this.Descripcio = sensorDto.Descripcio;
            this.Tipus = sensorDto.Tipus;
            this.ImatgeURL = sensorDto.ImatgeURL;
            this.Medicions = sensorDto.Medicions;

            return this;
        }
    }
}
