using ApiAgendaEducativaNet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Data.Repositories
{
    public interface ITipoEmpresaRepository
    {
        Task<IEnumerable<TipoEmpresa>> ObtenerTiposEmpresaAllAsync();
        Task<TipoEmpresa> ObtenerTipoEmpresaByIdAsync(int id);
        Task<TipoEmpresa> CrearTipoEmpresaAsync(TipoEmpresa tipoEmpresa);
        Task<TipoEmpresa> ActualizarTipoEmpresaAsync(int id,TipoEmpresa tipoEmpresa);
        Task<bool> EliminarTipoEmpresaAsync(int id);
    }
}
