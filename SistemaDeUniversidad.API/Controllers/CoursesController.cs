using Microsoft.AspNetCore.Mvc;
using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.API.DTO.Responses;
using SistemaDeUniversidad.Contracts.Services;
using SistemaDeUniversidad.Services;
using SistemaDeUniversidad.API.DTO;
using SistemaDeUniversidad.API.DTO.Requests;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeUniversidad.API.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService courseService;

        public CoursesController()
        {
            courseService = new CourseService();
        }

        [HttpGet]
        public async Task<IEnumerable<CoursesDTO>> GetAllAsync()
        {
            return (await courseService.GetAllAsync()).Select(c => ToDTO(c));
        }

        // GET 
        [HttpGet("{id}")]
        public async Task<ActionResult<CoursesDTO>> GetAsync(int id)
        {          
            try
            {
                return ToDTO(await courseService.GetByIdAsync(id));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        // POST
        [HttpPost]
        public async Task<ActionResult<CoursesDTO>> PostAsync([FromBody] CourseCreateDTO dto)
        {
            try
            {
                return ToDTO(await courseService.CreateAsync(dto.Name));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<ActionResult<CoursesDTO>> PutAsync(int id, [FromBody] CourseCreateDTO dto)
        {
            try
            {
                return ToDTO(await courseService.UpdateAsync(id, dto.Name));
            }
            catch (FileNotFoundException ex)
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
                await courseService.DeleteAsync(id);
                return NoContent();
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //Anotar alumno
        [HttpPost("{courseId}/students")]
        public async Task<ActionResult> EnrollStudent(int courseId, [FromBody] StudentEnrollDTO dto)
        {
            try
            {
                await courseService.EnrollStudentAsync(courseId, dto.Id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //Anotar profesor
        [HttpPost("{courseId}/profesors")]
        public async Task<ActionResult> EnrollProfessor(int courseId, [FromBody] ProfesorEnrollDTO dto)
        {           
            try
            {
                await courseService.EnrollProfessorAsync(courseId, dto.Id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        internal static CoursesDTO ToDTO(Course c)
        {
            return new CoursesDTO(c.Id, c.Name);
        }
    }
}
