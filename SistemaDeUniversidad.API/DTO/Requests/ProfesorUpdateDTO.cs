namespace SistemaDeUniversidad.API.DTO.Requests
{
    public class ProfesorUpdateDTO
    {
        public string Name { get; init; }
        public string Id { get; init; }

        public ProfesorUpdateDTO(string name, string id)
        {
            Name = name;
            Id = id;
        }
    }
}
