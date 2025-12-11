using ApiAgendaEducativaNet.Common;
using ApiAgendaEducativaNet.Data.Repositories;
using ApiAgendaEducativaNet.Models.Entities;
using ApiAgendaEducativaNet.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Services.Implementations
{
    public class TipoEmpresaService : ITipoEmpresaService
    {
        private readonly ITipoEmpresaRepository _repository;

        public TipoEmpresaService(ITipoEmpresaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TipoEmpresa>> ObtenerTiposEmpresaAllAsync()
        {
            return await _repository.ObtenerTiposEmpresaAllAsync();
        }

        public async Task<TipoEmpresa> ObtenerTipoEmpresaByIdAsync(int id)
        {
            return await _repository.ObtenerTipoEmpresaByIdAsync(id);
        }

        public async Task<ApiResponse<TipoEmpresa>> CrearTipoEmpresaAsync(TipoEmpresa tipoEmpresa)
        {
            //return await _repository.CrearTipoEmpresaAsync(tipoEmpresa);
            var existente = await _repository.ObtenerTiposEmpresaAllAsync();
            string NombreTipoEmpresa = tipoEmpresa.NombreTipoEmpresa;
            if (existente.Any(t => t.NombreTipoEmpresa.ToLower() == NombreTipoEmpresa.ToLower()))
            {
                return new ApiResponse<TipoEmpresa>("El nombre del tipo de empresa " + NombreTipoEmpresa + " ya existe.");
            }

            var creado = await _repository.CrearTipoEmpresaAsync(tipoEmpresa);
            return new ApiResponse<TipoEmpresa>(creado);
        }

        public async Task<ApiResponse<TipoEmpresa>> ActualizarTipoEmpresaAsync(int id, TipoEmpresa tipoEmpresa)
        {
            // Validar que el nombre no exista en otro registro
            var existente = await _repository.ObtenerTiposEmpresaAllAsync();
            string NombreTipoEmpresa = tipoEmpresa.NombreTipoEmpresa;
            if (existente.Any(t => t.IdTipoEmpresa != id &&
                                   t.NombreTipoEmpresa.ToLower() == NombreTipoEmpresa.ToLower()))
            {
                return new ApiResponse<TipoEmpresa>("El nombre del tipo de empresa " + NombreTipoEmpresa + "ya existe.");
            }

            tipoEmpresa.IdTipoEmpresa = id;
            var actualizado = await _repository.ActualizarTipoEmpresaAsync(id,tipoEmpresa);
            return new ApiResponse<TipoEmpresa>(actualizado);
        }


        public async Task<bool> EliminarTipoEmpresaAsync(int id)
        {
            return await _repository.EliminarTipoEmpresaAsync(id);
        }
    }
}
