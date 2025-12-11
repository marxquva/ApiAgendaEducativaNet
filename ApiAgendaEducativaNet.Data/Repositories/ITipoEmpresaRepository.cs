using ApiAgendaEducativaNet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Data.Repositories
{
    public interface ITipoEmpresaRepository
    {
        Task<IEnumerable<TipoEmpresa>> GetAllAsync();
        Task<TipoEmpresa> GetByIdAsync(int id);
        Task<TipoEmpresa> AddAsync(TipoEmpresa tipoEmpresa);
        Task<TipoEmpresa> UpdateAsync(TipoEmpresa tipoEmpresa);
        Task<bool> DeleteAsync(int id);
    }
}
