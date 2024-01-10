using System.ComponentModel.DataAnnotations;

namespace SistemaDeUniversidad.API.DTO.Responses
{
    public class StudentDTO
    {
        [Required]
        public int Id { get; init; }
        [Required]
        public string Name { get; init; }

        public StudentDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
