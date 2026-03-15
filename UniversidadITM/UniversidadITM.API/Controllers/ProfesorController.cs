using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversidadITM.Domain.Dtos;
using UniversidadITM.Domain.Interfaces;

namespace UniversidadITM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorService _service;

        public ProfesorController(IProfesorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfesorDto>>> Get()
        {
            var profesores = await _service.ObtenerTodosAsync();
            return Ok(profesores);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProfesorCreateDto dto)
        {
            await _service.RegistrarProfesorAsync(dto);
            return Ok(new { message = "Profesor registrado exitosamente." });
        }
    }
}
