using ApiAgendaEducativaNet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Services.Interfaces
{
    public interface IEmpresaService
    {
        Task<IEnumerable<Empresa>> GetAllEmpresasAsync();
        Task<Empresa> GetEmpresaByIdAsync(int id);
        Task<Empresa> CreateEmpresaAsync(Empresa empresa);
        Task<Empresa> UpdateEmpresaAsync(int id, Empresa empresa);
        Task<bool> DeleteEmpresaAsync(int id);

    }
}
