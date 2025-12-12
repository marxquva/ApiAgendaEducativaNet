using ApiAgendaEducativaNet.Models.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Models.Dtos
{
    public class EmpresaResponseDTO
    {
        public int IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string Descripcion { get; set; }
        public string TipoEmpresaNombre { get; set; }
        public string Imagen { get; set; }
        public string Direccion { get; set; }

        public List<NivelAcademicoResponseDTO> NivelesAcademicos { get; set; } = new List<NivelAcademicoResponseDTO>();
    }

}
