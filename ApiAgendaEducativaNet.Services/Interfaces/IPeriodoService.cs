using ApiAgendaEducativaNet.Common;
using ApiAgendaEducativaNet.Models.Dtos.Request;
using ApiAgendaEducativaNet.Models.Dtos.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Services.Interfaces
{
    public interface IPeriodoService
    {
        Task<ApiResponse<IEnumerable<PeriodoResponseDTO>>> ObtenerPeriodosAsync();
        Task<ApiResponse<PeriodoResponseDTO>> ObtenerPeriodoByIdAsync(int id);
        Task<ApiResponse<PeriodoResponseDTO>> CrearPeriodoAsync(PeriodoRequestDTO dto);
        Task<ApiResponse<PeriodoResponseDTO>> ActualizarPeriodoAsync(int id, PeriodoRequestDTO dto);
        Task<bool> EliminarPeriodoAsync(int id);
    }
}
