using System.ComponentModel.DataAnnotations;

namespace SistemaDeUniversidad.API.DTO
{
    public class StudentCreateDTO
    {
        public string Name { get; init; }

        public StudentCreateDTO(string name)
        {
            Name = name;
        }
    }
}
