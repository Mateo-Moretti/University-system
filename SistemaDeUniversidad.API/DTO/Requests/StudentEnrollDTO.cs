namespace SistemaDeUniversidad.API.DTO.Requests
{
    public class StudentEnrollDTO
    {
        public int Id { get; init; }

        public StudentEnrollDTO(int id)
        {
            Id = id;
        }
    }
}
