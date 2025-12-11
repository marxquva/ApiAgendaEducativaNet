using ApiAgendaEducativaNet.Data.Repositories;
using ApiAgendaEducativaNet.Models.Entities;
using ApiAgendaEducativaNet.Services.Interfaces;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Empresa>> GetAllEmpresasAsync()
        {
            return await _empresaRepository.GetAllAsync();
        }

        public async Task<Empresa> GetEmpresaByIdAsync(int id)
        {
            return await _empresaRepository.GetByIdAsync(id);
        }

        public async Task<Empresa> CreateEmpresaAsync(Empresa empresa)
        {
            await _empresaRepository.AddAsync(empresa);
            return empresa; // Retornar la entidad creada
        }


        public async Task<Empresa> UpdateEmpresaAsync(int id, Empresa empresa)
        {
            // Buscar empresa existente
            var existing = await _empresaRepository.GetByIdAsync(id);
            if (existing == null)
                return null;

            // Actualizar campos
            existing.NombreEmpresa = empresa.NombreEmpresa;
            existing.Descripcion = empresa.Descripcion;
            existing.Imagen = empresa.Imagen;
            existing.Direccion = empresa.Direccion;
            existing.IdTipoEmpresa = empresa.IdTipoEmpresa;
            existing.FechaModificacion = System.DateTime.Now;

            await _empresaRepository.UpdateAsync(existing);

            return existing;
        }


        public async Task<bool> DeleteEmpresaAsync(int id)
        {
            var existing = await _empresaRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            // Llamar al repositorio pasando el ID
            await _empresaRepository.DeleteAsync(id);
            return true;
        }


    }
}
