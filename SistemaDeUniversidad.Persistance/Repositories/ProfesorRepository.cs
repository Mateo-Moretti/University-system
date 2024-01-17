using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.Contracts.Repositories;
using Npgsql;

namespace SistemaDeUniversidad.Persistance.Repositories
{
    internal class ProfesorRepository : BaseRepository<Profesor>, IProfesorRepository
    {
        public ProfesorRepository(NpgsqlDataSource dataSource) : base(dataSource) { }

        public override async Task CreateAsync(Profesor entity)
        {
            string query = "INSERT INTO universidad.profesors(name) VALUES($1) RETURNING id";
            int ID = await ExecuteScalarIntAsync(query, new object[] { entity.Name });
            entity.Id = ID;
        }

        public override async Task DeleteAsync(int id)
        {
            string query = "DELETE FROM universidad.profesors WHERE id = $1";
            await ExecuteNonQueryAsync(query, new object[] { id });
        }

        public override async Task<Profesor?> GetByIdAsync(int id)
        {
            string query = "SELECT id, name FROM universidad.profesors WHERE id = $1";

            using NpgsqlDataReader reader = await GetQueryReaderAsync(query, new object[] { id });

            if (reader.Read())
            {
                return MapRowToModel(reader);
            }

            return null;
        }

        public override async Task UpdateAsync(Profesor entity)
        {
            string query = "UPDATE universidad.profesors SET name = $1 WHERE id = $2";
            await ExecuteNonQueryAsync(query, new object[] { entity.Name, entity.Id });
        }

        public override async Task<IEnumerable<Profesor>> GetAllAsync()
        {
            string query = "SELECT name, id FROM universidad.profesors";

            using NpgsqlDataReader reader = await GetQueryReaderAsync(query);

            var profesorsList = new List<Profesor>();

            while (reader.Read())
            {
                profesorsList.Add(MapRowToModel(reader));
            }

            return profesorsList;
        }

        protected override Profesor MapRowToModel(NpgsqlDataReader reader)
        {
            return new Profesor(
                    (string)reader["name"],
                    (int)reader["id"]);
        }






        // NOT YET IN USE

        public Task<bool> ExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task<List<Profesor>> GetByCourseAsync(int courseID)
        {
            throw new NotImplementedException();
        }

    }
}
