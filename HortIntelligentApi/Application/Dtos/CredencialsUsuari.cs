using System.ComponentModel.DataAnnotations;

namespace HortIntelligentApi.Application.Dtos
{
    public class CredencialsUsuari
    {
        [Required]
        public string Usuari { get; set; }
        [Required]
        public string Contrasenya { get; set; }
    }
}
