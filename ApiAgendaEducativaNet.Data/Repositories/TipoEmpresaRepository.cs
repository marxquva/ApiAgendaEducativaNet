using ApiAgendaEducativaNet.Data.Context;
using ApiAgendaEducativaNet.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Data.Repositories
{
    public class TipoEmpresaRepository : ITipoEmpresaRepository
    {
        private readonly AplicacionDbContext _context;

        public TipoEmpresaRepository(AplicacionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoEmpresa>> GetAllAsync()
        {
            return await _context.TipoEmpresas.ToListAsync();
        }

        public async Task<TipoEmpresa> GetByIdAsync(int id)
        {
            return await _context.TipoEmpresas.FindAsync(id);
        }

        public async Task<TipoEmpresa> AddAsync(TipoEmpresa tipoEmpresa)
        {
            _context.TipoEmpresas.Add(tipoEmpresa);
            await _context.SaveChangesAsync();
            return tipoEmpresa;
        }

        public async Task<TipoEmpresa> UpdateAsync(TipoEmpresa tipoEmpresa)
        {
            _context.TipoEmpresas.Update(tipoEmpresa);
            await _context.SaveChangesAsync();
            return tipoEmpresa;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.TipoEmpresas.FindAsync(id);
            if (entity == null) return false;

            _context.TipoEmpresas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
