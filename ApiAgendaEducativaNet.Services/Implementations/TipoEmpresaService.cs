using ApiAgendaEducativaNet.Data.Repositories;
using ApiAgendaEducativaNet.Models.Entities;
using ApiAgendaEducativaNet.Services.Interfaces;
using System.Collections.Generic;
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

        public async Task<IEnumerable<TipoEmpresa>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TipoEmpresa> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<TipoEmpresa> CreateAsync(TipoEmpresa tipoEmpresa)
        {
            return await _repository.AddAsync(tipoEmpresa);
        }

        public async Task<TipoEmpresa> UpdateAsync(TipoEmpresa tipoEmpresa)
        {
            return await _repository.UpdateAsync(tipoEmpresa);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
