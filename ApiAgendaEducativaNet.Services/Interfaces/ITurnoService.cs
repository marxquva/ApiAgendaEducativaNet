using ApiAgendaEducativaNet.Common;
using ApiAgendaEducativaNet.Models.Dtos;
using ApiAgendaEducativaNet.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Services.Interfaces
{
    public interface ITurnoService
    {
        Task<IEnumerable<TurnoResponseDTO>> ObtenerTurnosAsync();
        Task<TurnoResponseDTO> ObtenerTurnoByIdAsync(int id);
        Task<ApiResponse<TurnoResponseDTO>> CrearTurnoAsync(Turno turno);
        Task<ApiResponse<TurnoResponseDTO>> ActualizarTurnoAsync(int id, Turno turno);
        Task<bool> EliminarTurnoAsync(int id);
    }
}
