using System.ComponentModel.DataAnnotations;

namespace HortIntelligentApi.Application.Dtos
{
    public class EditarAdminDto
    {
        [Required]
        public string Usuari { get; set; }
    }
}
