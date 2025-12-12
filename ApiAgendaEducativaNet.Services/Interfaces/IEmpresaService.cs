using ApiAgendaEducativaNet.Models.Dtos;
using ApiAgendaEducativaNet.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Services.Interfaces
{
    public interface IEmpresaService
    {
        Task<IEnumerable<EmpresaResponseDTO>> ObtenerEmpresasAsync();
        Task<EmpresaResponseDTO> ObtenerEmpresaByIdAsync(int id);
        Task<EmpresaResponseDTO> CrearEmpresaAsync(Empresa empresa);
        Task<EmpresaResponseDTO> ActualizarEmpresaAsync(int id, Empresa empresa);
        Task<bool> EliminarEmpresaAsync(int id);
    }

}
