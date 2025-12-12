using ApiAgendaEducativaNet.Common;
using ApiAgendaEducativaNet.Data.Repositories;
using ApiAgendaEducativaNet.Models.Dtos;
using ApiAgendaEducativaNet.Models.Dtos.Request;
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

        public async Task<ApiResponse<NivelAcademicoResponseDTO>> CrearNivelAcademicoAsync(NivelAcademicoRequestDTO dto)
        {
            // Validación de duplicados
            var niveles = await _nivelRepository.ObtenerNivelesAcademicosAsync();
            if (niveles.Any(n =>
                n.IdEmpresa == dto.IdEmpresa &&
                n.Nombre.ToLower() == dto.Nombre.ToLower()))
            {
                return new ApiResponse<NivelAcademicoResponseDTO>(
                    $"El nombre '{dto.Nombre}' ya está registrado en esta empresa.",
                    new Dictionary<string, string[]> { { "Nombre", new[] { $"El nombre '{dto.Nombre}' ya está registrado en esta empresa." } } }
                );
            }

            var nivel = new NivelAcademico
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Estado = dto.Estado,
                IdEmpresa = dto.IdEmpresa
            };

            var creado = await _nivelRepository.CrearNivelAcademicoAsync(nivel);

            return new ApiResponse<NivelAcademicoResponseDTO>(MapToDto(creado));
        }


        public async Task<ApiResponse<NivelAcademicoResponseDTO>> ActualizarNivelAcademicoAsync(int id, NivelAcademicoRequestDTO dto)
        {
            var existente = await _nivelRepository.ObtenerNivelAcademicoByIdAsync(id);

            if (existente == null)
                return new ApiResponse<NivelAcademicoResponseDTO>(
                    $"El nivel académico no existe.",
                    new Dictionary<string, string[]> { { "Id", new[] { $"El nivel académico no existe." } } }
                );
            //return new ApiResponse<NivelAcademicoResponseDTO>("El nivel académico no existe.");

            // Validación duplicados
            var niveles = await _nivelRepository.ObtenerNivelesAcademicosAsync();
            if (niveles.Any(n =>
                n.IdNivelAcademico != id &&
                n.IdEmpresa == dto.IdEmpresa &&
                n.Nombre.ToLower() == dto.Nombre.ToLower()))
            {
                return new ApiResponse<NivelAcademicoResponseDTO>(
                    $"El nombre '{dto.Nombre}' ya está registrado en esta empresa.",
                    new Dictionary<string, string[]> { { "Nombre", new[] { $"El nombre '{dto.Nombre}' ya está registrado en esta empresa." } } }
                );

            }

            existente.Nombre = dto.Nombre;
            existente.Descripcion = dto.Descripcion;
            existente.Estado = dto.Estado;
            existente.IdEmpresa = dto.IdEmpresa;

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
