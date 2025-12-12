using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Models.Dtos.Request
{
    public class NivelAcademicoRequestDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Nombre { get; set; }

        [MaxLength(250)]
        public string Descripcion { get; set; }

        [Required]
        public int Estado { get; set; } = 1;

        [Required(ErrorMessage = "Debe seleccionar una empresa")]
        [Range(1, int.MaxValue, ErrorMessage = "IdEmpresa debe ser un número positivo")]
        public int IdEmpresa { get; set; }
    }

}
