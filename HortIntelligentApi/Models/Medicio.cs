using System.ComponentModel.DataAnnotations.Schema;

namespace HortIntelligentApi.Models
{
    public class Medicio
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }

        //FK
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }

        public int VegetalId { get; set; }
        public Vegetal Vegetal { get; set; }

        public int CampId { get; set; }
        public Camp Camp { get; set; }
    }
}
