using System.ComponentModel.DataAnnotations;

namespace SistemaDeUniversidad.API.DTO.Requests
{
    public class ProfesorCreateDTO
    {
        public string Name { get; init; }

        public ProfesorCreateDTO(string name)
        {
            Name = name;
        }
    }
}
