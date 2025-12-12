using ApiAgendaEducativaNet.Common;
using ApiAgendaEducativaNet.Models.Dtos.Response;
using ApiAgendaEducativaNet.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Services.Interfaces
{
    public interface INivelAcademicoService
    {
        Task<IEnumerable<NivelAcademicoResponseDTO>> ObtenerNivelesAcademicosAsync();
        Task<NivelAcademicoResponseDTO> ObtenerNivelAcademicoByIdAsync(int id);
        Task<ApiResponse<NivelAcademicoResponseDTO>> CrearNivelAcademicoAsync(NivelAcademico nivel);
        Task<ApiResponse<NivelAcademicoResponseDTO>> ActualizarNivelAcademicoAsync(int id, NivelAcademico nivel);
        Task<bool> EliminarNivelAcademicoAsync(int id);
    }
}
