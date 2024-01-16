namespace SistemaDeUniversidad.API.DTO.Requests
{
    public class StudentUpdateDTO
    {
        public string Name { get; init; }

        public StudentUpdateDTO(string name)
        {
            Name = name;
        }
    }
}
