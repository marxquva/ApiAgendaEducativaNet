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
        private readonly ITipoEmpresaService _service;

        public TipoEmpresaController(ITipoEmpresaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<TipoEmpresa>>>> obtenerTiposempresa()
        {
            var result = await _service.GetAllAsync();
            //return Ok(result);
            return Ok(new ApiResponse<IEnumerable<TipoEmpresa>>(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<TipoEmpresa>>> obtenerTipoempresaPorId(int id)
        {
            var tipoEmpresa = await _service.GetByIdAsync(id);
            if (tipoEmpresa == null)
                return NotFound(new ApiResponse<TipoEmpresa>("El tipo de empresa con ID " + id + " no existe"));
            return Ok(new ApiResponse<TipoEmpresa>(tipoEmpresa));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<TipoEmpresa>>> crearTipoempresa(TipoEmpresa tipoEmpresa)
        {
            var created = await _service.CreateAsync(tipoEmpresa);
            return CreatedAtAction(nameof(obtenerTipoempresaPorId), new { id = created.IdTipoEmpresa },
                new ApiResponse<TipoEmpresa>(created));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<TipoEmpresa>>> actualizarTipoempresaPorId(int id, TipoEmpresa tipoEmpresa)
        {
            // Obtener el registro existente
            var existing = await _service.GetByIdAsync(id);
            if (existing == null)
            {
                return NotFound(new ApiResponse<TipoEmpresa>($"El tipo de empresa con ID {id} no existe"));
            }

            // Actualizar solo los campos enviados
            existing.NombreTipoEmpresa = tipoEmpresa.NombreTipoEmpresa;
            existing.Descripcion = tipoEmpresa.Descripcion;
            existing.Estado = tipoEmpresa.Estado;
            existing.FechaModificacion = System.DateTime.Now;

            // Guardar cambios
            var updated = await _service.UpdateAsync(existing);

            return Ok(new ApiResponse<TipoEmpresa>(updated, "Tipo de empresa actualizada correctamente"));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<string>>> eliminarEmpresaPorId(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound(new ApiResponse<string>($"El tipo de empresa con ID {id} no existe"));

            // Aquí usamos el constructor que toma data + mensaje
            return Ok(new ApiResponse<string>(null, "Tipo de empresa eliminada correctamente"));
        }

    }
}
