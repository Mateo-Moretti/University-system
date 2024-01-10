using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.Contracts.Repositories;
using Npgsql;

namespace SistemaDeUniversidad.Persistance.Repositories
{
    //ACA SE GUARDA TODO LO QUE TENGA QUE VER CON LA TABLA ALUMNOS EN ANTARES (SQL)
    internal class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(NpgsqlDataSource dataSource) : base(dataSource) { }

        public override Task CreateAsync(Student entity)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Student>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAmountOfCorsesEnrolled(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetByCourseAsync(int courseId)
        {
            throw new NotImplementedException();
        }

        public override Task<Student?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(Student entity)
        {
            throw new NotImplementedException();
        }

        protected override Student MapRowToModel(NpgsqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
