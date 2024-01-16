using System.ComponentModel.DataAnnotations;

namespace SistemaDeUniversidad.API.DTO.Requests
{
    public class CourseCreateDTO
    {
        public string Name { get; init; }

        public CourseCreateDTO(string name)
        {
            Name = name;
        }
    }
}
