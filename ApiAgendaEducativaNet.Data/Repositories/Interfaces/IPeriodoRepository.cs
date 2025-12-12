using ApiAgendaEducativaNet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Data.Repositories.Interfaces
{
    public interface IPeriodoRepository
    {
        Task<IEnumerable<Periodo>> ObtenerPeriodosAsync();
        Task<Periodo> ObtenerPeriodoByIdAsync(int id);
        Task<Periodo> CrearPeriodoAsync(Periodo periodo);
        Task<Periodo> ActualizarPeriodoAsync(Periodo periodo);
        Task<bool> EliminarPeriodoAsync(int id);
    }
}
