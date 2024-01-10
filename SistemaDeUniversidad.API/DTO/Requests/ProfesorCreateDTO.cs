using System.ComponentModel.DataAnnotations;

namespace SistemaDeUniversidad.API.DTO.Requests
{
    public class ProfesorCreateDTO
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public int Id { get; init; }

        public ProfesorCreateDTO(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}
