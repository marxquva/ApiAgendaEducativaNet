using ApiAgendaEducativaNet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Data.Repositories
{
    public interface IEmpresaRepository
    {
        Task<IEnumerable<Empresa>> ObtenerEmpresasAsync();
        Task<Empresa> ObtenerEmpresaByIdAsync(int id);
        Task<Empresa> CrearEmpresaAsync(Empresa empresa);
        Task<Empresa> ActualizarEmpresaAsync(Empresa empresa);
        Task<bool> EliminarEmpresaAsync(int id);
    }
}
