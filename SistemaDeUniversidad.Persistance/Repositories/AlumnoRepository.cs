using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.Contracts.Repositories;
using Npgsql;


namespace SistemaDeUniversidad.Persistance.Repositories
{
    //ACA SE GUARDA TODO LO QUE TENGA QUE VER CON LA TABLA ALUMNOS EN ANTARES (SQL)
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public AlumnoRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task CreateAsync(Alumno alumno, string nombre, int id)
        {
            using var cmd = _dataSource.CreateCommand($"INSERT INTO universidad.alumnos(nombre, id) VALUES ('{nombre}', '{id}')");
            await cmd.ExecuteNonQueryAsync();
        }
  
        public async Task InscribirAMateria(int idAlumno, int idMateria)
        {
            using var cmd = _dataSource.CreateCommand($"INSERT INTO universidad.alumnos_cursan(alumno_id, materia_id) VALUES ('{idAlumno}', '{idMateria}')");
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DesinscribirDeMateria(int idAlumno, int idMateria)
        {
            using var cmd = _dataSource.CreateCommand($"DELETE FROM universidad.alumnos_cursan WHERE alumno_id = {idAlumno} AND materia_id = {idMateria}");
            await cmd.ExecuteNonQueryAsync();
        }

   
    }
}
