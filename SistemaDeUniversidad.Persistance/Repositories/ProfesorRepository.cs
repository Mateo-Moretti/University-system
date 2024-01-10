using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.Contracts.Repositories;
using Npgsql;

namespace SistemaDeUniversidad.Persistance.Repositories
{
    //ACA SE GUARDA TODO LO QUE TENGA QUE VER CON LA TABLA PROFESORES EN ANTARES (SQL)
    internal class ProfesorRepository : BaseRepository<Profesor>, IProfesorRepository
    {
        public ProfesorRepository(NpgsqlDataSource dataSource) : base(dataSource) { }


        public override Task CreateAsync(Profesor entity)
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

        public override Task<IEnumerable<Profesor>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Profesor>> GetByCourseAsync(int courseID)
        {
            throw new NotImplementedException();
        }

        public override Task<Profesor?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(Profesor entity)
        {
            throw new NotImplementedException();
        }

        protected override Profesor MapRowToModel(NpgsqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
