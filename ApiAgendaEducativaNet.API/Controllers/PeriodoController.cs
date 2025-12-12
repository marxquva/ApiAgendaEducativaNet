using ApiAgendaEducativaNet.Common;
using ApiAgendaEducativaNet.Models.Dtos.Request;
using ApiAgendaEducativaNet.Models.Dtos.Response;
using ApiAgendaEducativaNet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodoController : ControllerBase
    {
        private readonly IPeriodoService _periodoService;

        public PeriodoController(IPeriodoService periodoService)
        {
            _periodoService = periodoService;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<ApiResponse<IEnumerable<PeriodoResponseDTO>>>> ObtenerPeriodos()
        {
            var response = await _periodoService.ObtenerPeriodosAsync();
            return Ok(response);
        }

        [HttpGet("item/{id}")]
        public async Task<ActionResult<ApiResponse<PeriodoResponseDTO>>> ObtenerPeriodoById(int id)
        {
            var response = await _periodoService.ObtenerPeriodoByIdAsync(id);
            if (response == null || response.Data == null)
            {
                var errores = new Dictionary<string, string[]>
                {
                    { "Id", new[] { "No existe el periodo académico." } }
                };

                return NotFound(new ApiResponse<PeriodoResponseDTO>(
                    "No existe el periodo académico.",
                    errores
                ));
            }

            return Ok(response);
        }

        [HttpPost("crear")]
        public async Task<ActionResult<ApiResponse<PeriodoResponseDTO>>> CrearPeriodo([FromBody] PeriodoRequestDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var errores = ModelState
                    .Where(ms => ms.Value.Errors.Any())
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());

                return BadRequest(new ApiResponse<PeriodoResponseDTO>("Errores de validación.", errores));
            }

            var response = await _periodoService.CrearPeriodoAsync(dto);
            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<ApiResponse<PeriodoResponseDTO>>> ActualizarPeriodo(int id, [FromBody] PeriodoRequestDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var errores = ModelState
                    .Where(ms => ms.Value.Errors.Any())
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());

                return BadRequest(new ApiResponse<PeriodoResponseDTO>("Errores de validación.", errores));
            }

            var response = await _periodoService.ActualizarPeriodoAsync(id, dto);
            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult<ApiResponse<string>>> EliminarPeriodo(int id)
        {
            var eliminado = await _periodoService.EliminarPeriodoAsync(id);
            if (!eliminado)
            {
                var errores = new Dictionary<string, string[]>
                {
                    { "Id", new[] { "El periodo académico no existe." } }
                };

                return NotFound(new ApiResponse<string>(
                    "No se pudo eliminar el periodo académico.",
                    errores
                ));
            }

            return Ok(new ApiResponse<string>(null, "Periodo académico eliminado correctamente."));
        }
    }
}
