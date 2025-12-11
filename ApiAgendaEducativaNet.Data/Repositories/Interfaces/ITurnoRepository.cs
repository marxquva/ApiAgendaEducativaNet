using ApiAgendaEducativaNet.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Data.Repositories
{
    public interface ITurnoRepository
    {
        Task<IEnumerable<Turno>> ObtenerTurnosAsync();
        Task<Turno> ObtenerTurnoByIdAsync(int id);
        Task<Turno> CrearTurnoAsync(Turno turno);
        Task<Turno> ActualizarTurnoAsync(Turno turno);
        Task<bool> EliminarTurnoAsync(int id);
    }
}
