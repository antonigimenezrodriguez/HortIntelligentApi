using HortIntelligentApi.Application.Dtos;

namespace HortIntelligentApi.Domini.Entitats
{
    public class Vegetal
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Descripcio { get; set; }
        public string ImatgeURL { get; set; }
        public decimal? TemperaturaMaxima { get; set; }
        public decimal? TemperaturaMinima { get; set; }
        public decimal? TemperaturaOptima { get; set; }
        public decimal? HumitatMaxima { get; set; }
        public decimal? HumitatMinima { get; set; }
        public decimal? HumitatOptima { get; set; }

        public HashSet<Medicio> Medicions { get; set; }
        public HashSet<Camp> Camps { get; set; }

        public Vegetal() { }
        public Vegetal(int id, string nom, string descripcio, string imatgeURL, decimal? temperaturaMaxima, decimal? temperaturaMinima, decimal? temperaturaOptima, decimal? humitatMaxima, decimal? humitatMinima, decimal? humitatOptima, HashSet<Medicio> medicions = null, HashSet<Camp> camps = null)
        {
            Id = id;
            Nom = nom;
            Descripcio = descripcio;
            ImatgeURL = imatgeURL;
            TemperaturaMaxima = temperaturaMaxima;
            TemperaturaMinima = temperaturaMinima;
            TemperaturaOptima = temperaturaOptima;
            HumitatMaxima = humitatMaxima;
            HumitatMinima = humitatMinima;
            HumitatOptima = humitatOptima;
            Medicions = medicions;
            Camps = camps;
        }

        public Vegetal Actualitzar(VegetalDto vegetalDto)
        {
            this.Id = vegetalDto.Id;
            this.Nom = vegetalDto.Nom;
            this.Descripcio = vegetalDto.Descripcio;
            this.ImatgeURL = vegetalDto.ImatgeURL;
            this.TemperaturaMaxima = vegetalDto.TemperaturaMaxima;
            this.TemperaturaMinima = vegetalDto.TemperaturaMinima;
            this.TemperaturaOptima = vegetalDto.TemperaturaOptima;
            this.HumitatMaxima = vegetalDto.HumitatMaxima;
            this.HumitatMinima = vegetalDto.HumitatMinima;
            this.HumitatOptima = vegetalDto.HumitatOptima;
            this.Medicions = vegetalDto.Medicions;
            this.Camps = vegetalDto.Camps;
            return this;
        }
    }
}
