using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.Contracts.Repositories;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

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
    }
}
