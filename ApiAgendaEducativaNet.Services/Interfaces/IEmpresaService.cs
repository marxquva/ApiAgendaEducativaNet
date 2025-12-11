using ApiAgendaEducativaNet.Models.Dtos;
using ApiAgendaEducativaNet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Services.Interfaces
{
    public interface IEmpresaService
    {
        Task<IEnumerable<EmpresaDTO>> ObtenerEmpresasAsync();
        Task<EmpresaDTO> ObtenerEmpresaByIdAsync(int id);
        Task<EmpresaDTO> CrearEmpresaAsync(Empresa empresa);
        Task<EmpresaDTO> ActualizarEmpresaAsync(int id, Empresa empresa);
        Task<bool> EliminarEmpresaAsync(int id);
    }

}
