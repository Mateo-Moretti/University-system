using Microsoft.AspNetCore.Mvc;
using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.API.DTO.Responses;
using SistemaDeUniversidad.Contracts.Services;
using SistemaDeUniversidad.Services;
using SistemaDeUniversidad.API.DTO;
using Microsoft.AspNetCore.Cors.Infrastructure;
using SistemaDeUniversidad.API.DTO.Requests;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeUniversidad.API.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentsService;

        public StudentsController()
        {
            studentsService = new StudentService();
        }

        [HttpGet]
        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            return (await studentsService.GetAllAsync()).Select(s => ToDTO(s));
        }

        // GET 
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetAsync(int id)
        {
            try
            {
                return ToDTO(await studentsService.GetByIdAsync(id));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
          
            }
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<StudentDTO>> PostAsync([FromBody] StudentCreateDTO dto)
        {
            try
            {
                return ToDTO(await studentsService.CreateAsync(dto.Name));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDTO>> PutAsync(int id, [FromBody] StudentCreateDTO dto)
        {
            try
            {
                return ToDTO(await studentsService.UpdateAsync(id, dto.Name));
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
                await studentsService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        internal static StudentDTO ToDTO(Student s)
        {
            return new StudentDTO(s.Id, s.Name);
        }
    }
}
