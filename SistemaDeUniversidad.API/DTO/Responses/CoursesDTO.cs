using System.ComponentModel.DataAnnotations;

namespace SistemaDeUniversidad.API.DTO.Responses
{
    public class CoursesDTO
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public CoursesDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
