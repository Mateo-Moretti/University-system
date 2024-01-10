using System.ComponentModel.DataAnnotations;

namespace SistemaDeUniversidad.API.DTO.Requests
{
    public class CourseCreateDTO
    {
        public string Name { get; init; }
        public int Id { get; init; }

        public CourseCreateDTO(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}
