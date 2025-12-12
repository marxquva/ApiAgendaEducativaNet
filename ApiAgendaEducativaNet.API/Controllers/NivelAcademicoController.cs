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
    public class NivelAcademicoController : ControllerBase
    {
        private readonly INivelAcademicoService _nivelService;

        public NivelAcademicoController(INivelAcademicoService nivelService)
        {
            _nivelService = nivelService;
        }

        // GET api/nivelacademico/listar
        [HttpGet("listar")]
        public async Task<ActionResult<ApiResponse<IEnumerable<NivelAcademicoResponseDTO>>>> ObtenerNivelesAcademicos()
        {
            var datos = await _nivelService.ObtenerNivelesAcademicosAsync();
            return Ok(new ApiResponse<IEnumerable<NivelAcademicoResponseDTO>>(datos));
        }

        // GET api/nivelacademico/item/1
        [HttpGet("item/{id}")]
        public async Task<ActionResult<ApiResponse<NivelAcademicoResponseDTO>>> ObtenerNivelAcademicoById(int id)
        {
            var dato = await _nivelService.ObtenerNivelAcademicoByIdAsync(id);
            if (dato == null)
            {
                var errores = new Dictionary<string, string[]>
                {
                    { "Id", new[] { "No existe el nivel académico." } }
                };

                return NotFound(new ApiResponse<NivelAcademicoResponseDTO>(
                    "No existe el nivel académico.",
                    errores
                ));
            }

            return Ok(new ApiResponse<NivelAcademicoResponseDTO>(dato));
        }

        // POST api/nivelacademico/crear
        [HttpPost("crear")]
        public async Task<ActionResult<ApiResponse<NivelAcademicoResponseDTO>>> CrearNivelAcademico([FromBody] NivelAcademicoRequestDTO nivel)
        {
            if (!ModelState.IsValid)
            {
                var errores = ObtenerErroresModelState();

                return BadRequest(
                    new ApiResponse<NivelAcademicoResponseDTO>(
                        "Errores de validación.",
                        errores
                    )
                );
            }

            var response = await _nivelService.CrearNivelAcademicoAsync(nivel);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        // PUT api/nivelacademico/actualizar/3
        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<ApiResponse<NivelAcademicoResponseDTO>>> ActualizarNivelAcademico(int id, [FromBody] NivelAcademicoRequestDTO nivel)
        {
            if (!ModelState.IsValid)
            {
                var errores = ObtenerErroresModelState();

                return BadRequest(
                    new ApiResponse<NivelAcademicoResponseDTO>(
                        "Errores de validación.",
                        errores
                    )
                );
            }

            var response = await _nivelService.ActualizarNivelAcademicoAsync(id, nivel);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        // DELETE api/nivelacademico/eliminar/3
        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult<ApiResponse<string>>> EliminarNivelAcademico(int id)
        {
            var eliminado = await _nivelService.EliminarNivelAcademicoAsync(id);

            if (!eliminado)
            {
                var errores = new Dictionary<string, string[]>
                {
                    { "Id", new[] { "El nivel académico no existe." } }
                };

                return NotFound(new ApiResponse<string>(
                    "No se pudo eliminar el nivel académico.",
                    errores
                ));
            }

            return Ok(new ApiResponse<string>(null, "Nivel académico eliminado correctamente."));
        }


        private Dictionary<string, string[]> ObtenerErroresModelState()
        {
            return ModelState
                .Where(ms => ms.Value.Errors.Any())
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors
                        .Select(e => e.ErrorMessage)
                        .ToArray()
                );
        }
    }
}
