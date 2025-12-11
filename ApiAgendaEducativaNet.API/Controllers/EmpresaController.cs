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
        [HttpGet("listar")]
        public async Task<ActionResult<ApiResponse<IEnumerable<EmpresaDTO>>>> ObtenerEmpresas()
        {
            var response = await _empresaService.ObtenerEmpresasAsync();
            return Ok(new ApiResponse<IEnumerable<EmpresaDTO>>(response));
        }


        // GET api/empresa/item/5
        [HttpGet("item/{id}")]
        public async Task<ActionResult<ApiResponse<EmpresaDTO>>> ObtenerEmpresaPorId(int id)
        {
            var response = await _empresaService.ObtenerEmpresaByIdAsync(id);

            if (response == null)
                return NotFound(new ApiResponse<EmpresaDTO>($"La empresa con ID {id} no existe"));

            return Ok(new ApiResponse<EmpresaDTO>(response));
        }


        // POST api/empresa/crear
        [HttpPost("crear")]
        public async Task<ActionResult<ApiResponse<EmpresaDTO>>> CrearEmpresa([FromBody] Empresa empresa)
        {
            var response = await _empresaService.CrearEmpresaAsync(empresa);

            return CreatedAtAction(nameof(ObtenerEmpresaPorId),
                new { id = response.IdEmpresa },
                new ApiResponse<EmpresaDTO>(response));
        }


        // PUT api/empresa/modificar/5
        [HttpPut("modificar/{id}")]
        public async Task<ActionResult<ApiResponse<EmpresaDTO>>> actualizarEmpresaPorId(int id, [FromBody] Empresa empresaActualizada)
        {
            var response = await _empresaService.ActualizarEmpresaAsync(id, empresaActualizada);

            if (response == null)
                return NotFound(new ApiResponse<EmpresaDTO>($"La empresa con ID {id} no existe"));

            return Ok(new ApiResponse<EmpresaDTO>(response, "Empresa actualizada correctamente"));
        }



        // DELETE api/empresa/eliminar/5
        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult<ApiResponse<string>>> eliminarEmpresaPorId(int id)
        {
            var eliminado = await _empresaService.EliminarEmpresaAsync(id);

            if (!eliminado)
                return NotFound(new ApiResponse<string>($"La empresa con ID {id} no existe"));

            return Ok(new ApiResponse<string>(null, "Empresa eliminada correctamente"));
        }

    }
}
