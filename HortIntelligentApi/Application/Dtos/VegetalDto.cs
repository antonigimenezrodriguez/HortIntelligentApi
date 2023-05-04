using HortIntelligentApi.Domini.Entitats;

namespace HortIntelligentApi.Application.Dtos
{
    public class VegetalDto
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
    }
}
