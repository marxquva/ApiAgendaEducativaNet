using ApiAgendaEducativaNet.Common;
using ApiAgendaEducativaNet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Services.Interfaces
{
    public interface ITipoEmpresaService
    {
        Task<IEnumerable<TipoEmpresa>> ObtenerTiposEmpresaAllAsync();
        Task<TipoEmpresa> ObtenerTipoEmpresaByIdAsync(int id);

        // Ahora devuelve ApiResponse para poder retornar mensajes de validación
        Task<ApiResponse<TipoEmpresa>> CrearTipoEmpresaAsync(TipoEmpresa tipoEmpresa);
        Task<ApiResponse<TipoEmpresa>> ActualizarTipoEmpresaAsync(int id, TipoEmpresa tipoEmpresa);

        Task<bool> EliminarTipoEmpresaAsync(int id);
    }
}
