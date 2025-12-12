using ApiAgendaEducativaNet.Common;
using ApiAgendaEducativaNet.Data.Repositories;
using ApiAgendaEducativaNet.Models.Dtos;
using ApiAgendaEducativaNet.Models.Dtos.Response;
using ApiAgendaEducativaNet.Models.Entities;
using ApiAgendaEducativaNet.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Services.Implementations
{
    public class NivelAcademicoService : INivelAcademicoService
    {
        private readonly INivelAcademicoRepository _nivelRepository;

        public NivelAcademicoService(INivelAcademicoRepository nivelRepository)
        {
            _nivelRepository = nivelRepository;
        }

        public async Task<IEnumerable<NivelAcademicoResponseDTO>> ObtenerNivelesAcademicosAsync()
        {
            var niveles = await _nivelRepository.ObtenerNivelesAcademicosAsync();
            return niveles.Select(MapToDto);
        }

        public async Task<NivelAcademicoResponseDTO> ObtenerNivelAcademicoByIdAsync(int id)
        {
            var nivel = await _nivelRepository.ObtenerNivelAcademicoByIdAsync(id);
            return MapToDto(nivel);
        }

        public async Task<ApiResponse<NivelAcademicoResponseDTO>> CrearNivelAcademicoAsync(NivelAcademico nivel)
        {
            var existentes = await _nivelRepository.ObtenerNivelesAcademicosAsync();

            if (existentes.Any(n =>
                n.IdEmpresa == nivel.IdEmpresa &&
                n.Nombre.ToLower() == nivel.Nombre.ToLower()))
            {
                return new ApiResponse<NivelAcademicoResponseDTO>(
                    $"El nombre del nivel académico '{nivel.Nombre}' ya existe para esta empresa."
                );
            }

            var creado = await _nivelRepository.CrearNivelAcademicoAsync(nivel);
            return new ApiResponse<NivelAcademicoResponseDTO>(MapToDto(creado));
        }

        public async Task<ApiResponse<NivelAcademicoResponseDTO>> ActualizarNivelAcademicoAsync(int id, NivelAcademico nivel)
        {
            var existente = await _nivelRepository.ObtenerNivelAcademicoByIdAsync(id);

            if (existente == null)
                return new ApiResponse<NivelAcademicoResponseDTO>("El nivel académico no existe.");

            var niveles = await _nivelRepository.ObtenerNivelesAcademicosAsync();
            if (niveles.Any(n =>
                n.IdNivelAcademico != id &&
                n.IdEmpresa == nivel.IdEmpresa &&
                n.Nombre.ToLower() == nivel.Nombre.ToLower()))
            {
                return new ApiResponse<NivelAcademicoResponseDTO>(
                    $"El nombre '{nivel.Nombre}' ya existe para esta empresa."
                );
            }

            // Actualizar
            existente.Nombre = nivel.Nombre;
            existente.Descripcion = nivel.Descripcion;
            existente.Estado = nivel.Estado;
            existente.IdEmpresa = nivel.IdEmpresa;

            var actualizado = await _nivelRepository.ActualizarNivelAcademicoAsync(existente);

            return new ApiResponse<NivelAcademicoResponseDTO>(MapToDto(actualizado));
        }

        public Task<bool> EliminarNivelAcademicoAsync(int id)
            => _nivelRepository.EliminarNivelAcademicoAsync(id);

        private NivelAcademicoResponseDTO MapToDto(NivelAcademico nivel)
        {
            if (nivel == null) return null;

            return new NivelAcademicoResponseDTO
            {
                IdNivelAcademico = nivel.IdNivelAcademico,
                Nombre = nivel.Nombre,
                Descripcion = nivel.Descripcion,
                Estado = nivel.Estado,
                EmpresaNombre = nivel.Empresa?.NombreEmpresa
            };
        }
    }
}
