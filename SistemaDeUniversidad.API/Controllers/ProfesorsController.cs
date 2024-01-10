using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.API.DTO.Requests;
using SistemaDeUniversidad.API.DTO.Responses;
using SistemaDeUniversidad.Contracts.Services;
using SistemaDeUniversidad.Services;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeUniversidad.API.Controllers
{
    [Route("api/profesors")]
    [ApiController]
    public class ProfesorsController : ControllerBase
    {
        private readonly IProfesorService profesorService;

        public ProfesorsController()
        {
            profesorService = new ProfesorService();
        }

        [HttpGet]
        public async Task<IEnumerable<ProfesorDTO>> GetAllAsync()
        {
            return (await profesorService.GetAllAsync()).Select(p => ToDTO(p));
        }

        // GET 
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfesorDTO>> GetAsync(int id)
        {
            try
            {
                return ToDTO(await profesorService.GetByIdAsync(id));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        // POST
        [HttpPost]
        public async Task<ActionResult<ProfesorDTO>> PostAsync([FromBody] ProfesorCreateDTO dto)
        {
            try
            {
                return ToDTO(await profesorService.CreateAsync(dto.Name));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<ActionResult<ProfesorDTO>> PutAsync(int id, [FromBody] ProfesorCreateDTO dto)
        {
            try
            {
                return ToDTO(await profesorService.UpdateAsync(id, dto.Name));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //DELETE por id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await profesorService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        internal static ProfesorDTO ToDTO(Profesor p)
        {
            return new ProfesorDTO(p.Id, p.Name);
        }
    }
}
