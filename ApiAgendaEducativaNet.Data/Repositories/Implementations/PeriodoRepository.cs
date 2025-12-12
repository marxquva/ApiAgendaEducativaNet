using ApiAgendaEducativaNet.Data.Context;
using ApiAgendaEducativaNet.Data.Repositories.Interfaces;
using ApiAgendaEducativaNet.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Data.Repositories.Implementations
{
    public class PeriodoRepository : IPeriodoRepository
    {
        private readonly AplicacionDbContext _context;

        public PeriodoRepository(AplicacionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Periodo>> ObtenerPeriodosAsync()
        {
            return await _context.Periodos.ToListAsync();
        }

        public async Task<Periodo> ObtenerPeriodoByIdAsync(int id)
        {
            return await _context.Periodos.FirstOrDefaultAsync(p => p.IdPeriodo == id);
        }

        public async Task<Periodo> CrearPeriodoAsync(Periodo periodo)
        {
            await _context.Periodos.AddAsync(periodo);
            await _context.SaveChangesAsync();
            return periodo;
        }

        public async Task<Periodo> ActualizarPeriodoAsync(Periodo periodo)
        {
            _context.Periodos.Update(periodo);
            await _context.SaveChangesAsync();
            return periodo;
        }

        public async Task<bool> EliminarPeriodoAsync(int id)
        {
            var periodo = await _context.Periodos.FindAsync(id);
            if (periodo == null) return false;

            _context.Periodos.Remove(periodo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
