using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.Contracts.Repositories;
using Npgsql;

namespace SistemaDeUniversidad.Persistance.Repositories
{
    internal class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(NpgsqlDataSource dataSource) : base(dataSource) { }

        public override async Task CreateAsync(Course entity)
        {
            string query = "INSERT INTO universidad.courses(name) VALUES($1) RETURNING id";
            int ID = await ExecuteScalarIntAsync(query, new object[] { entity.Name });
            entity.Id = ID;
        }

        public override async Task DeleteAsync(int id)
        {
            string query = "DELETE FROM universidad.courses WHERE id = $1";
            await ExecuteNonQueryAsync(query, new object[] { id });
        }

        public override async Task<Course?> GetByIdAsync(int id)
        {
            string query = "SELECT id, name FROM universidad.courses WHERE id = $1";

            using NpgsqlDataReader reader = await GetQueryReaderAsync(query, new object[] { id });

            if (reader.Read())
            {
                return MapRowToModel(reader);
            }

            return null;
        }


        public override async Task UpdateAsync(Course entity)
        {
            string query = "UPDATE universidad.courses SET name = $1 WHERE id = $2";
            await ExecuteNonQueryAsync(query, new object[] { entity.Name, entity.Id });
        }

        public override async Task<IEnumerable<Course>> GetAllAsync()
        {
            string query = "SELECT name, id FROM universidad.courses";

            using NpgsqlDataReader reader = await GetQueryReaderAsync(query);

            var coursesList = new List<Course>();

            while (reader.Read())
            {
                coursesList.Add(MapRowToModel(reader));
            }

            return coursesList;
        }

        protected override Course MapRowToModel(NpgsqlDataReader reader)
        {
            return new Course(
                    (string)reader["name"],
                    (int)reader["id"]);
        }





        // NOT YET IN USE

        public async Task<List<Course>> GetByNameAsync(string name)
        {
            string query = "SELECT * FROM universidad.courses WHERE name ILIKE $1%"; 

            using NpgsqlDataReader reader = await GetQueryReaderAsync(query, new object[] { name });

            var listaCourses = new List<Course>();

            while (reader.Read())
            {
                listaCourses.Add(MapRowToModel(reader));
            }
            return listaCourses;
        }

        public Task<List<Course>> GetByStudentAsync(int studentID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetByProfesorAsync(int professorId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EnrollStudentAsync(int studentId, int courseId)
        {
            throw new NotImplementedException();
        }

        public Task EnrollProfesorAsync(int professorId, int courseId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProfesorAsync(int professorId, int courseId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveStudentAsync(int studentId, int courseId)
        {
            throw new NotImplementedException();
        }
    }
}
