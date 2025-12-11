using ApiAgendaEducativaNet.Common;
using ApiAgendaEducativaNet.Data.Repositories;
using ApiAgendaEducativaNet.Models.Dtos;
using ApiAgendaEducativaNet.Models.Entities;
using ApiAgendaEducativaNet.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiAgendaEducativaNet.Services.Implementations
{
    public class TurnoService : ITurnoService
    {

        private readonly ITurnoRepository _turnoRepository;

        public TurnoService(ITurnoRepository turnoRepository)
        {
            _turnoRepository = turnoRepository;
        }

        public async Task<IEnumerable<TurnoResponseDTO>> ObtenerTurnosAsync()
        {
            var turnos = await _turnoRepository.ObtenerTurnosAsync();
            return turnos.Select(MapToDto).ToList();
        }

        public async Task<TurnoResponseDTO> ObtenerTurnoByIdAsync(int id)
        {
            var turno = await _turnoRepository.ObtenerTurnoByIdAsync(id);
            return MapToDto(turno);
        }

        public async Task<ApiResponse<TurnoResponseDTO>> CrearTurnoAsync(Turno turno)
        {
            // Validar nombre duplicado dentro de la misma empresa
            var existentes = await _turnoRepository.ObtenerTurnosAsync();
            if (existentes.Any(t => t.IdEmpresa == turno.IdEmpresa && t.Nombre.ToLower() == turno.Nombre.ToLower()))
            {
                return new ApiResponse<TurnoResponseDTO>($"El nombre del turno '{turno.Nombre}' ya existe para esta empresa.");
            }

            var creado = await _turnoRepository.CrearTurnoAsync(turno);
            return new ApiResponse<TurnoResponseDTO>(MapToDto(creado));
        }

        public async Task<ApiResponse<TurnoResponseDTO>> ActualizarTurnoAsync(int id, Turno turno)
        {
            var existente = await _turnoRepository.ObtenerTurnoByIdAsync(id);
            if (existente == null)
                return new ApiResponse<TurnoResponseDTO>("El turno no existe.");

            // Validar duplicado dentro de la misma empresa, excluyendo el turno actual
            var turnos = await _turnoRepository.ObtenerTurnosAsync();
            if (turnos.Any(t => t.IdTurno != id && t.IdEmpresa == turno.IdEmpresa && t.Nombre.ToLower() == turno.Nombre.ToLower()))
            {
                return new ApiResponse<TurnoResponseDTO>($"El nombre del turno '{turno.Nombre}' ya existe para esta empresa.");
            }

            // Actualizar propiedades
            existente.Nombre = turno.Nombre;
            existente.Descripcion = turno.Descripcion;
            existente.HoraInicio = turno.HoraInicio;
            existente.HoraFinal = turno.HoraFinal;
            existente.Estado = turno.Estado;
            existente.IdEmpresa = turno.IdEmpresa;

            var actualizado = await _turnoRepository.ActualizarTurnoAsync(existente);
            return new ApiResponse<TurnoResponseDTO>(MapToDto(actualizado));
        }



        public Task<bool> EliminarTurnoAsync(int id)
            => _turnoRepository.EliminarTurnoAsync(id);

        private TurnoResponseDTO MapToDto(Turno turno)
        {
            if (turno == null) return null;

            return new TurnoResponseDTO
            {
                IdTurno = turno.IdTurno,
                Nombre = turno.Nombre,
                Descripcion = turno.Descripcion,
                HoraInicio = turno.HoraInicio,
                HoraFinal = turno.HoraFinal,
                Estado = turno.Estado,
                EmpresaNombre = turno.Empresa?.NombreEmpresa
            };
        }

    }
}
