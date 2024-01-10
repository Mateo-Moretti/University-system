using System.ComponentModel.DataAnnotations;

namespace SistemaDeUniversidad.API.DTO
{
    public class StudentCreateDTO
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public int Id { get; init; }

        public StudentCreateDTO(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}
