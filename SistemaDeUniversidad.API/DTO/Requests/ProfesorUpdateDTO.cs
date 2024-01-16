namespace SistemaDeUniversidad.API.DTO.Requests
{
    public class ProfesorUpdateDTO
    {
        public string Name { get; init; }

        public ProfesorUpdateDTO(string name)
        {
            Name = name;
        }
    }
}
