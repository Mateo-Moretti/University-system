using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.Contracts.Repositories;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeUniversidad.Persistance.Repositories
{
    //ACA SE GUARDA TODO LO QUE TENGA QUE VER CON LA TABLA PROFESORES EN ANTARES (SQL)
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public ProfesorRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task CreateAsync(Profesor profesor, string nombre, int id)
        {
            using var cmd = _dataSource.CreateCommand($"INSERT INTO universidad.profesores(nombre, id) VALUES ('{nombre}', '{id}')");
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task InscribirAMateria(int idProfesor, int idMateria)
        {
            using var cmd = _dataSource.CreateCommand($"INSERT INTO universidad.profesores_dictan(profesor_id, materia_id) VALUES ('{idProfesor}', '{idMateria}')");
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
