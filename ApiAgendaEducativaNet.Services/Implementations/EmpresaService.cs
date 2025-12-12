using ApiAgendaEducativaNet.Data.Repositories;
using ApiAgendaEducativaNet.Models.Dtos;
using ApiAgendaEducativaNet.Models.Entities;
using ApiAgendaEducativaNet.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Services.Implementations
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<IEnumerable<EmpresaResponseDTO>> ObtenerEmpresasAsync()
        {
            var empresas = await _empresaRepository.ObtenerEmpresasAsync();

            return empresas.Select(e => MapToDto(e));
        }

        public async Task<EmpresaResponseDTO> ObtenerEmpresaByIdAsync(int id)
        {
            var empresa = await _empresaRepository.ObtenerEmpresaByIdAsync(id);

            if (empresa == null)
                return null;

            return MapToDto(empresa);
        }


        public async Task<EmpresaResponseDTO> CrearEmpresaAsync(Empresa empresa)
        {
            // Validar nombre duplicado
            var existentes = await _empresaRepository.ObtenerEmpresasAsync();
            if (existentes.Any(e => e.NombreEmpresa.ToLower() == empresa.NombreEmpresa.ToLower()))
            {
                return null; // El controlador devolverá el mensaje según tu lógica
            }

            var creada = await _empresaRepository.CrearEmpresaAsync(empresa);

            return MapToDto(creada);
        }

        public async Task<EmpresaResponseDTO> ActualizarEmpresaAsync(int id, Empresa empresa)
        {
            var existente = await _empresaRepository.ObtenerEmpresaByIdAsync(id);

            if (existente == null)
                return null;

            // Validar nombre duplicado (excluyendo la empresa actual)
            var empresas = await _empresaRepository.ObtenerEmpresasAsync();
            if (empresas.Any(e =>
                e.IdEmpresa != id &&
                e.NombreEmpresa.ToLower() == empresa.NombreEmpresa.ToLower()))
            {
                return null;
            }

            // Actualizar campos permitidos
            existente.NombreEmpresa = empresa.NombreEmpresa;
            existente.Descripcion = empresa.Descripcion;
            existente.Imagen = empresa.Imagen;
            existente.Direccion = empresa.Direccion;
            existente.IdTipoEmpresa = empresa.IdTipoEmpresa;

            var actualizada = await _empresaRepository.ActualizarEmpresaAsync(existente);

            return MapToDto(actualizada);
        }

        public Task<bool> EliminarEmpresaAsync(int id)
            => _empresaRepository.EliminarEmpresaAsync(id);

        private EmpresaResponseDTO MapToDto(Empresa empresa)
        {
            if (empresa == null) return null;

            return new EmpresaResponseDTO
            {
                IdEmpresa = empresa.IdEmpresa,
                NombreEmpresa = empresa.NombreEmpresa,
                Descripcion = empresa.Descripcion,
                Imagen = empresa.Imagen,
                Direccion = empresa.Direccion,
                TipoEmpresaNombre = empresa.TipoEmpresa?.NombreTipoEmpresa
            };
        }



    }
}
