using ApiAgendaEducativaNet.Common;
using ApiAgendaEducativaNet.Models.Dtos;
using ApiAgendaEducativaNet.Models.Entities;
using ApiAgendaEducativaNet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase { 

        private readonly ITurnoService _turnoService;
        public TurnoController(ITurnoService turnoService)
        {
            _turnoService = turnoService;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<ApiResponse<IEnumerable<TurnoResponseDTO>>>> ObtenerTurnos()
        {
            var turnosDto = await _turnoService.ObtenerTurnosAsync();
            return Ok(new ApiResponse<IEnumerable<TurnoResponseDTO>>(turnosDto));
        }

        [HttpGet("item/{id}")]
        public async Task<ActionResult<ApiResponse<TurnoResponseDTO>>> ObtenerTurno(int id)
        {
            var turnoDto = await _turnoService.ObtenerTurnoByIdAsync(id);

            if (turnoDto == null)
                return NotFound(new ApiResponse<TurnoResponseDTO>("Turno no encontrado."));

            return Ok(new ApiResponse<TurnoResponseDTO>(turnoDto));
        }


        [HttpPost("crear")]
        public async Task<ActionResult<ApiResponse<TurnoResponseDTO>>> CrearTurno([FromBody] Turno turno)
        {
            var response = await _turnoService.CrearTurnoAsync(turno);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult<ApiResponse<TurnoResponseDTO>>> ActualizarTurno(int id, [FromBody] Turno turno)
        {
            var response = await _turnoService.ActualizarTurnoAsync(id, turno);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> EliminarTurno(int id)
        {
            var eliminado = await _turnoService.EliminarTurnoAsync(id);

            if (!eliminado)
                return NotFound(new ApiResponse<bool>("Turno no encontrado."));

            return Ok(new ApiResponse<bool>(true, "Turno eliminado correctamente."));
        }



    }
}
