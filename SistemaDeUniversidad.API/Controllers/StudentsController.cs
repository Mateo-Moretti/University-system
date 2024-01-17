using Microsoft.AspNetCore.Mvc;
using SistemaDeUniversidad.API.DTO;
using SistemaDeUniversidad.API.DTO.Responses;
using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.Contracts.Services;
using SistemaDeUniversidad.Services;

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

        // GET ALL
        [HttpGet]
        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            return (await studentsService.GetAllAsync()).Select(s => ToDTO(s));
        }

        // GET 
        [HttpGet("{id}")]
        public async Task<StudentDTO> GetAsync(int id)
        {
            return ToDTO(await studentsService.GetByIdAsync(id));
        }

        // POST
        [HttpPost]
        public async Task<StudentDTO> PostAsync([FromBody] StudentCreateDTO dto)
        {
            return ToDTO(await studentsService.CreateAsync(dto.Name));
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<StudentDTO> PutAsync(int id, [FromBody] StudentCreateDTO dto)
        {
            return ToDTO(await studentsService.UpdateAsync(id, dto.Name));
        }

        //DELETE por id
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await studentsService.DeleteAsync(id);
        }

        internal static StudentDTO ToDTO(Student s)
        {
            return new StudentDTO(s.Id, s.Name);
        }
    }
}
