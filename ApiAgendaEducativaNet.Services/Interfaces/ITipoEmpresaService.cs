using ApiAgendaEducativaNet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Services.Interfaces
{
    public interface ITipoEmpresaService
    {
        Task<IEnumerable<TipoEmpresa>> GetAllAsync();
        Task<TipoEmpresa> GetByIdAsync(int id);
        Task<TipoEmpresa> CreateAsync(TipoEmpresa tipoEmpresa);
        Task<TipoEmpresa> UpdateAsync(TipoEmpresa tipoEmpresa);
        Task<bool> DeleteAsync(int id);
    }
}
