namespace HuertoInteligenteApi.Models
{
    public class Vegetal
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Descripcio { get; set; }
        public string ImatgeURL { get; set; }
        public decimal TemperaturaMaxima { get; set; }
        public decimal TemperatiraMinima { get; set; }
        public decimal TemperaturaOptima { get; set; }
        public decimal HumitatMaxima { get; set; }
        public decimal HumitatMinima { get; set; }
        public decimal HumitatOptima { get; set; }
    }
}
