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
    //ACA SE GUARDA TODO LO QUE TENGA QUE VER CON LA TABLA MATERIAS EN ANTARES (SQL)
    public class MateriaRepository : IMateriaRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public MateriaRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task CreateAsync(Materia Materia, string nombre, int id)
        {
            using var cmd = _dataSource.CreateCommand($"INSERT INTO universidad.materias(nombre, id) VALUES ('{nombre}', '{id}')");
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
