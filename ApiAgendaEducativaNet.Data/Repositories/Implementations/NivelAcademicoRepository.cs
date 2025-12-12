using ApiAgendaEducativaNet.Data.Context;
using ApiAgendaEducativaNet.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Data.Repositories.Implementations
{
    public class NivelAcademicoRepository : INivelAcademicoRepository
    {
        private readonly AplicacionDbContext _context;

        public NivelAcademicoRepository(AplicacionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NivelAcademico>> ObtenerNivelesAcademicosAsync()
        {
            return await _context.NivelesAcademicos
                .Include(n => n.Empresa)
                .ToListAsync();
        }

        public async Task<NivelAcademico> ObtenerNivelAcademicoByIdAsync(int id)
        {
            return await _context.NivelesAcademicos
                .Include(n => n.Empresa)
                .FirstOrDefaultAsync(n => n.IdNivelAcademico == id);
        }

        public async Task<NivelAcademico> CrearNivelAcademicoAsync(NivelAcademico nivel)
        {
            await _context.NivelesAcademicos.AddAsync(nivel);
            await _context.SaveChangesAsync();
            return nivel;
        }

        public async Task<NivelAcademico> ActualizarNivelAcademicoAsync(NivelAcademico nivel)
        {
            _context.NivelesAcademicos.Update(nivel);
            await _context.SaveChangesAsync();
            return nivel;
        }

        public async Task<bool> EliminarNivelAcademicoAsync(int id)
        {
            var entidad = await _context.NivelesAcademicos.FindAsync(id);
            if (entidad == null)
                return false;

            _context.NivelesAcademicos.Remove(entidad);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
