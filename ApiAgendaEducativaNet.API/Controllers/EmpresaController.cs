using ApiAgendaEducativaNet.Models.Entities;
using ApiAgendaEducativaNet.Models.Dtos;
using ApiAgendaEducativaNet.Services.Interfaces;
using ApiAgendaEducativaNet.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ApiAgendaEducativaNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }


        // GET api/empresa/listar
        [HttpGet("Listar")]
        public async Task<ActionResult<ApiResponse<IEnumerable<EmpresaDTO>>>> obtenerEmpresas()
        {
            var empresas = await _empresaService.GetAllEmpresasAsync();

            var empresasDto = empresas.Select(e => new EmpresaDTO
            {
                IdEmpresa = e.IdEmpresa,
                NombreEmpresa = e.NombreEmpresa,
                Descripcion = e.Descripcion,
                Imagen = e.Imagen,
                Direccion = e.Direccion,
                TipoEmpresaNombre = e.TipoEmpresa?.NombreTipoEmpresa
            }).ToList();

            return Ok(new ApiResponse<IEnumerable<EmpresaDTO>>(empresasDto));
        }


        // GET api/empresa/registro/5
        [HttpGet("Registro/{id}")]
        public async Task<ActionResult<ApiResponse<EmpresaDTO>>> obtenerEmpresaPorId(int id)
        {
            var empresa = await _empresaService.GetEmpresaByIdAsync(id);
            if (empresa == null)
                return NotFound(new ApiResponse<EmpresaDTO>("La empresa con ID " + id + " no existe"));

            var empresaDto = new EmpresaDTO
            {
                IdEmpresa = empresa.IdEmpresa,
                NombreEmpresa = empresa.NombreEmpresa,
                Descripcion = empresa.Descripcion,
                Imagen = empresa.Imagen,
                Direccion = empresa.Direccion,
                TipoEmpresaNombre = empresa.TipoEmpresa?.NombreTipoEmpresa
            };

            return Ok(new ApiResponse<EmpresaDTO>(empresaDto));
        }


        // POST api/empresa/guardar
        [HttpPost("Guardar")]
        public async Task<ActionResult<ApiResponse<Empresa>>> crearEmpresa(Empresa empresa)
        {
            var created = await _empresaService.CreateEmpresaAsync(empresa);
            return CreatedAtAction(nameof(obtenerEmpresaPorId), new { id = created.IdEmpresa },
                new ApiResponse<Empresa>(created));
        }


        // PUT api/empresa/modificar/5
        [HttpPut("Modificar/{id}")]
        public async Task<ActionResult<ApiResponse<EmpresaDTO>>> actualizarEmpresaPorId(int id, [FromBody] Empresa empresaActualizada)
        {
            // Obtener la empresa existente
            var empresaExistente = await _empresaService.GetEmpresaByIdAsync(id);
            if (empresaExistente == null)
                return NotFound(new ApiResponse<EmpresaDTO>($"La empresa con ID {id} no existe"));

            // Actualizar los datos usando el servicio
            var empresaModificada = await _empresaService.UpdateEmpresaAsync(id, empresaActualizada);

            // Convertir a DTO
            var empresaDto = new EmpresaDTO
            {
                IdEmpresa = empresaModificada.IdEmpresa,
                NombreEmpresa = empresaModificada.NombreEmpresa,
                Descripcion = empresaModificada.Descripcion,
                Imagen = empresaModificada.Imagen,
                Direccion = empresaModificada.Direccion,
                TipoEmpresaNombre = empresaModificada.TipoEmpresa?.NombreTipoEmpresa
            };

            return Ok(new ApiResponse<EmpresaDTO>(empresaDto, "Empresa actualizada correctamente"));
        }




        // DELETE api/empresa/eliminar/5
        [HttpDelete("Eliminar/{id}")]
        public async Task<ActionResult<ApiResponse<string>>> eliminarEmpresaPorId(int id)
        {
            var deleted = await _empresaService.DeleteEmpresaAsync(id);
            if (!deleted)
                return NotFound(new ApiResponse<string>($"La empresa con ID {id} no existe"));

            return Ok(new ApiResponse<string>(null, "Empresa eliminada correctamente"));
        }

    }
}
