using System.ComponentModel.DataAnnotations;

namespace SistemaDeUniversidad.API.DTO.Responses
{
    public class ProfesorDTO
    {
        [Required]
        public int Id { get; init; }
        [Required]
        public string Name { get; init; }

        public ProfesorDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
