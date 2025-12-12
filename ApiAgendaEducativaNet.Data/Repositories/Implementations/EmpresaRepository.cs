using ApiAgendaEducativaNet.Data.Context;
using ApiAgendaEducativaNet.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Data.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {

        private readonly AplicacionDbContext _context;

        public EmpresaRepository(AplicacionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empresa>> ObtenerEmpresasAsync()
        {
            return await _context.Empresas
                .Include(e => e.TipoEmpresa)
                .Include(e => e.NivelesAcademicos)
                .ToListAsync();
        }


        public async Task<Empresa> ObtenerEmpresaByIdAsync(int id)
        {
            return await _context.Empresas
                .Include(e => e.TipoEmpresa)
                .Include(e => e.NivelesAcademicos)
                .FirstOrDefaultAsync(e => e.IdEmpresa == id);
        }

        public async Task<Empresa> CrearEmpresaAsync(Empresa empresa)
        {
            await _context.Empresas.AddAsync(empresa);
            await _context.SaveChangesAsync();
            return empresa;
        }

        public async Task<Empresa> ActualizarEmpresaAsync(Empresa empresa)
        {
            _context.Empresas.Update(empresa);
            await _context.SaveChangesAsync();
            return empresa;
        }

        public async Task<bool> EliminarEmpresaAsync(int id)
        {
            var entidad = await _context.Empresas.FindAsync(id);
            if (entidad == null)
                return false;

            _context.Empresas.Remove(entidad);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
