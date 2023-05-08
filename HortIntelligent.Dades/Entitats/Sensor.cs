using HortIntelligent.Dades.Herlper;
using System.ComponentModel;

namespace HortIntelligent.Dades.Entitats
{
    public class Sensor : ISoftDelete
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Model { get; set; }
        public string Descripcio { get; set; }
        public EnumTipusSensor Tipus { get; set; }
        public string ImatgeURL { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        //Navegació
        public HashSet<Medicio> Medicions { get; set; }


    }
}
