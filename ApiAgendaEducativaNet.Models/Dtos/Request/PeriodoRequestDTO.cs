using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Models.Dtos.Request
{
    public class PeriodoRequestDTO
    {
        [Required(ErrorMessage = "El codigo es obligatorio")]
        [MaxLength(4, ErrorMessage = "El codigo no puede exceder 4 caracteres")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int Estado { get; set; } = 1;
    }
}
