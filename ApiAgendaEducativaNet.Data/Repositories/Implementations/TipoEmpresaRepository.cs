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

        public async Task<IEnumerable<TipoEmpresa>> ObtenerTiposEmpresaAllAsync()
        {
            return await _context.TipoEmpresas.ToListAsync();
        }

        public async Task<TipoEmpresa> ObtenerTipoEmpresaByIdAsync(int id)
        {
            return await _context.TipoEmpresas.FindAsync(id);
        }

        public async Task<TipoEmpresa> CrearTipoEmpresaAsync(TipoEmpresa tipoEmpresa)
        {
            _context.TipoEmpresas.Add(tipoEmpresa);
            await _context.SaveChangesAsync();
            return tipoEmpresa;
        }

        public async Task<TipoEmpresa> ActualizarTipoEmpresaAsync(int id, TipoEmpresa tipoEmpresa)
        {
            var existente = await _context.TipoEmpresas.FindAsync(id);
            if (existente == null) return null;

            // Actualizar propiedades
            existente.NombreTipoEmpresa = tipoEmpresa.NombreTipoEmpresa;
            existente.Descripcion = tipoEmpresa.Descripcion;

            await _context.SaveChangesAsync();
            return existente;
        }



        public async Task<bool> EliminarTipoEmpresaAsync(int id)
        {
            var entity = await _context.TipoEmpresas.FindAsync(id);
            if (entity == null) return false;

            _context.TipoEmpresas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
