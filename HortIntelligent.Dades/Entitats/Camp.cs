using HortIntelligent.Dades.Herlper;
using System.ComponentModel;

namespace HortIntelligent.Dades.Entitats
{
    public class Camp : ISoftDelete
    {
        public int Id { get; set; }
        public string Localitzacio { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Observacions { get; set; }
        public string ImatgeURL { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        //FK
        public int? VegetalId { get; set; }
        public Vegetal Vegetal { get; set; }
    }
}
