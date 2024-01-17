using Microsoft.AspNetCore.Mvc;
using SistemaDeUniversidad.API.DTO.Requests;
using SistemaDeUniversidad.API.DTO.Responses;
using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.Contracts.Services;
using SistemaDeUniversidad.Services;

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

        // GET ALL
        [HttpGet]
        public async Task<IEnumerable<ProfesorDTO>> GetAllAsync()
        {
            return (await profesorService.GetAllAsync()).Select(p => ToDTO(p));
        }

        // GET 
        [HttpGet("{id}")]
        public async Task<ProfesorDTO> GetAsync(int id)
        {
           return ToDTO(await profesorService.GetByIdAsync(id));
        }

        // POST
        [HttpPost]
        public async Task<ProfesorDTO> PostAsync([FromBody] ProfesorCreateDTO dto)
        {
            return ToDTO(await profesorService.CreateAsync(dto.Name));
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<ProfesorDTO> PutAsync(int id, [FromBody] ProfesorCreateDTO dto)
        {
           return ToDTO(await profesorService.UpdateAsync(id, dto.Name));
        }

        //DELETE por id
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
           await profesorService.DeleteAsync(id);
        }

        internal static ProfesorDTO ToDTO(Profesor p)
        {
            return new ProfesorDTO(p.Id, p.Name);
        }
    }
}
