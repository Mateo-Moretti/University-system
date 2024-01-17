using Microsoft.AspNetCore.Mvc;
using SistemaDeUniversidad.API.DTO.Requests;
using SistemaDeUniversidad.API.DTO.Responses;
using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.Contracts.Services;
using SistemaDeUniversidad.Services;

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

        // GET ALL
        [HttpGet]
        public async Task<IEnumerable<CoursesDTO>> GetAllAsync()
        {
            return (await courseService.GetAllAsync()).Select(c => ToDTO(c));
        }

        // GET 
        [HttpGet("{id}")]
        public async Task<CoursesDTO> GetAsync(int id)
        {          
            return ToDTO(await courseService.GetByIdAsync(id));
        }

        // POST
        [HttpPost]
        public async Task<CoursesDTO> PostAsync([FromBody] CourseCreateDTO dto)
        {          
            return ToDTO(await courseService.CreateAsync(dto.Name));           
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<CoursesDTO> PutAsync(int id, [FromBody] CourseCreateDTO dto)
        {
            return ToDTO(await courseService.UpdateAsync(id, dto.Name));
        }

        //DELETE por id
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await courseService.DeleteAsync(id);
        }

        /*
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
        */
        internal static CoursesDTO ToDTO(Course c)
        {
            return new CoursesDTO(c.Id, c.Name);
        }
    }
}
