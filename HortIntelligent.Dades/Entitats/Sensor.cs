namespace HortIntelligent.Dades.Entitats
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
    }
}
