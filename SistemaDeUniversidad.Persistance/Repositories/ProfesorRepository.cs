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

        public Task CreateAsync(Profesor profesor)
        {
            throw new NotImplementedException();
        }
    }
}
