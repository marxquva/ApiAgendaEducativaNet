using ApiAgendaEducativaNet.Models.Entities;
using ApiAgendaEducativaNet.Services.Interfaces;
using ApiAgendaEducativaNet.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEmpresaController : ControllerBase
    {
        private readonly ITipoEmpresaService _tipoEmpresaService;

        public TipoEmpresaController(ITipoEmpresaService service)
        {
            _tipoEmpresaService = service;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<ApiResponse<IEnumerable<TipoEmpresa>>>> ObtenerTiposempresa()
        {
            var result = await _tipoEmpresaService.ObtenerTiposEmpresaAllAsync();
            //return Ok(result);
            return Ok(new ApiResponse<IEnumerable<TipoEmpresa>>(result));
        }

        [HttpGet("item/{id}")]
        public async Task<ActionResult<ApiResponse<TipoEmpresa>>> ObtenerTipoempresaPorId(int id)
        {
            var tipoEmpresa = await _tipoEmpresaService.ObtenerTipoEmpresaByIdAsync(id);
            if (tipoEmpresa == null)
                return NotFound(new ApiResponse<TipoEmpresa>("El tipo de empresa con ID " + id + " no existe"));
            return Ok(new ApiResponse<TipoEmpresa>(tipoEmpresa));
        }

        [HttpPost("crear")]
        public async Task<ActionResult<ApiResponse<TipoEmpresa>>> CrearTipoEmpresa([FromBody] TipoEmpresa tipoEmpresa)
        {
            var response = await _tipoEmpresaService.CrearTipoEmpresaAsync(tipoEmpresa);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<ApiResponse<TipoEmpresa>>> ActualizarTipoEmpresa(int id, [FromBody] TipoEmpresa tipoEmpresa)
        {
            var response = await _tipoEmpresaService.ActualizarTipoEmpresaAsync(id, tipoEmpresa);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }


        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult<ApiResponse<string>>> EliminarEmpresaPorId(int id)
        {
            var deleted = await _tipoEmpresaService.EliminarTipoEmpresaAsync(id);
            if (!deleted)
                return NotFound(new ApiResponse<string>($"El tipo de empresa con ID {id} no existe"));

            // Aquí usamos el constructor que toma data + mensaje
            return Ok(new ApiResponse<string>(null, "Tipo de empresa eliminada correctamente"));
        }

    }
}
