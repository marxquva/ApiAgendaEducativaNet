using ApiAgendaEducativaNet.Data.Context;
using ApiAgendaEducativaNet.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Data.Repositories.Implementations
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly AplicacionDbContext _context;

        public TurnoRepository(AplicacionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Turno>> ObtenerTurnosAsync()
        {
            return await _context.Turnos
                .Include(t => t.Empresa)
                .ToListAsync();
        }

        public async Task<Turno> ObtenerTurnoByIdAsync(int id)
        {
            return await _context.Turnos
                .Include(t => t.Empresa)
                .FirstOrDefaultAsync(t => t.IdTurno == id);
        }

        public async Task<Turno> CrearTurnoAsync(Turno turno)
        {
            await _context.Turnos.AddAsync(turno);
            await _context.SaveChangesAsync();
            return turno;
        }

        public async Task<Turno> ActualizarTurnoAsync(Turno turno)
        {
            _context.Turnos.Update(turno);
            await _context.SaveChangesAsync();
            return turno;
        }

        public async Task<bool> EliminarTurnoAsync(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null)
                return false;

            _context.Turnos.Remove(turno);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
