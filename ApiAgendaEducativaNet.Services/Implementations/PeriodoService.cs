using ApiAgendaEducativaNet.Common;
using ApiAgendaEducativaNet.Data.Repositories.Interfaces;
using ApiAgendaEducativaNet.Models.Dtos.Request;
using ApiAgendaEducativaNet.Models.Dtos.Response;
using ApiAgendaEducativaNet.Models.Entities;
using ApiAgendaEducativaNet.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Services.Implementations
{
    public class PeriodoService : IPeriodoService
    {
        private readonly IPeriodoRepository _periodoRepository;

        public PeriodoService(IPeriodoRepository periodoRepository)
        {
            _periodoRepository = periodoRepository;
        }

        public async Task<ApiResponse<IEnumerable<PeriodoResponseDTO>>> ObtenerPeriodosAsync()
        {
            var periodos = await _periodoRepository.ObtenerPeriodosAsync();
            var data = periodos.Select(MapToDto);
            return new ApiResponse<IEnumerable<PeriodoResponseDTO>>(data);
        }

        public async Task<ApiResponse<PeriodoResponseDTO>> ObtenerPeriodoByIdAsync(int id)
        {
            var periodo = await _periodoRepository.ObtenerPeriodoByIdAsync(id);
            if (periodo == null)
                return null;

            return new ApiResponse<PeriodoResponseDTO>(MapToDto(periodo));
        }

        public async Task<ApiResponse<PeriodoResponseDTO>> CrearPeriodoAsync(PeriodoRequestDTO dto)
        {
            // Validar codigo duplicado
            var existentes = await _periodoRepository.ObtenerPeriodosAsync();
            if (existentes.Any(p => p.Codigo.ToLower() == dto.Codigo.ToLower()))
            {
                var errores = new Dictionary<string, string[]>
                {
                    { "Codigo", new[] { "El codigo ya existe." } }
                };
                return new ApiResponse<PeriodoResponseDTO>("El codigo ya existe.", errores);
            }

            var periodo = new Periodo
            {
                Codigo = dto.Codigo,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                FechaInicio = dto.FechaInicio,
                FechaFinal = dto.FechaFinal,
                Estado = dto.Estado
            };

            var creado = await _periodoRepository.CrearPeriodoAsync(periodo);
            return new ApiResponse<PeriodoResponseDTO>(MapToDto(creado));
        }

        public async Task<ApiResponse<PeriodoResponseDTO>> ActualizarPeriodoAsync(int id, PeriodoRequestDTO dto)
        {
            var existente = await _periodoRepository.ObtenerPeriodoByIdAsync(id);
            if (existente == null)
                return new ApiResponse<PeriodoResponseDTO>("No existe el periodo académico.");

            // Validar codigo duplicado (excepto el actual)
            var periodos = await _periodoRepository.ObtenerPeriodosAsync();
            if (periodos.Any(p => p.IdPeriodo != id && p.Codigo.ToLower() == dto.Codigo.ToLower()))
            {
                var errores = new Dictionary<string, string[]>
                {
                    { "Codigo", new[] { "El codigo ya existe." } }
                };
                return new ApiResponse<PeriodoResponseDTO>("El codigo ya existe.", errores);
            }

            existente.Codigo = dto.Codigo;
            existente.Nombre = dto.Nombre;
            existente.Descripcion = dto.Descripcion;
            existente.FechaInicio = dto.FechaInicio;
            existente.FechaFinal = dto.FechaFinal;
            existente.Estado = dto.Estado;

            var actualizado = await _periodoRepository.ActualizarPeriodoAsync(existente);
            return new ApiResponse<PeriodoResponseDTO>(MapToDto(actualizado));
        }

        public async Task<bool> EliminarPeriodoAsync(int id)
        {
            return await _periodoRepository.EliminarPeriodoAsync(id);
        }

        private PeriodoResponseDTO MapToDto(Periodo periodo)
        {
            return new PeriodoResponseDTO
            {
                IdPeriodo = periodo.IdPeriodo,
                Codigo = periodo.Codigo,
                Nombre = periodo.Nombre,
                Descripcion = periodo.Descripcion,
                FechaInicio = periodo.FechaInicio,
                FechaFinal = periodo.FechaFinal,
                Estado = periodo.Estado
            };
        }
    }
}
