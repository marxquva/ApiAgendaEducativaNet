using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Models.Dtos
{
    public class TurnoResponseDTO
    {
        public int IdTurno { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? HoraInicio { get; set; }
        public DateTime? HoraFinal { get; set; }
        public int Estado { get; set; }
        public string EmpresaNombre { get; set; }
    }
}
