using HortIntelligentApi.Application.Dtos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace HortIntelligentApi.Domini.Entitats
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

        public Medicio() { }
        public Medicio(int id, decimal valor, DateTime dataHora, int sensorId, int vegetalId, int campId)
        {
            Id = id;
            Valor = valor;
            DataHora = dataHora;
            SensorId = sensorId;
            VegetalId = vegetalId;
            CampId = campId;
        }
        public Medicio Actualitzar(MedicioDto medicioDto)
        {
            this.Id = medicioDto.Id;
            this.Valor = medicioDto.Valor;
            this.DataHora = medicioDto.DataHora;
            this.SensorId = medicioDto.SensorId;
            this.VegetalId = medicioDto.VegetalId;
            this.CampId = medicioDto.CampId;
            return this;
        }
    }
}
