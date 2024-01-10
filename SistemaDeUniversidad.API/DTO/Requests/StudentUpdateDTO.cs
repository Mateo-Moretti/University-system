namespace SistemaDeUniversidad.API.DTO.Requests
{
    public class StudentUpdateDTO
    {
        public string Name { get; init; }
        public string Id { get; init; }

        public StudentUpdateDTO(string name, string id)
        {
            Name = name;
            Id = id;
        }
    }
}
