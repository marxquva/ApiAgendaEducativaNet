using ApiAgendaEducativaNet.Common;
using ApiAgendaEducativaNet.Models.Dtos.Response;
using ApiAgendaEducativaNet.Models.Entities;
using ApiAgendaEducativaNet.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("listar")]
        public async Task<ActionResult<ApiResponse<IEnumerable<NivelAcademicoResponseDTO>>>> Listar()
        {
            var datos = await _nivelService.ObtenerNivelesAcademicosAsync();
            return Ok(new ApiResponse<IEnumerable<NivelAcademicoResponseDTO>>(datos));
        }

        [HttpGet("item/{id}")]
        public async Task<ActionResult<ApiResponse<NivelAcademicoResponseDTO>>> Obtener(int id)
        {
            var dato = await _nivelService.ObtenerNivelAcademicoByIdAsync(id);
            if (dato == null)
                return NotFound(new ApiResponse<NivelAcademicoResponseDTO>("No existe el nivel académico."));

            return Ok(new ApiResponse<NivelAcademicoResponseDTO>(dato));
        }

        [HttpPost("crear")]
        public async Task<ActionResult<ApiResponse<NivelAcademicoResponseDTO>>> Crear([FromBody] NivelAcademico model)
        {
            var response = await _nivelService.CrearNivelAcademicoAsync(model);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<ApiResponse<NivelAcademicoResponseDTO>>> Actualizar(int id, [FromBody] NivelAcademico model)
        {
            var response = await _nivelService.ActualizarNivelAcademicoAsync(id, model);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult<ApiResponse<string>>> Eliminar(int id)
        {
            var eliminado = await _nivelService.EliminarNivelAcademicoAsync(id);

            if (!eliminado)
                return NotFound(new ApiResponse<string>("El nivel académico no existe."));

            return Ok(new ApiResponse<string>(null, "Nivel académico eliminado correctamente."));
        }


    }
}
