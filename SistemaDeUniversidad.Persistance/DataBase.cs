using SistemaDeUniversidad.Contracts.Repositories;
using SistemaDeUniversidad.Persistance.Repositories;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemadeUniversidad.Contracts.Models;

namespace SistemaDeUniversidad.Persistance
{
    public static class DataBase
    {
        private static readonly NpgsqlDataSource _dataSource;

        static DataBase()
        {
            _dataSource = NpgsqlDataSource.Create("Host=127.0.0.1;Username=postgres;Password=2007;Database=postgres");
            Alumnos = new AlumnoRepository(_dataSource);
            Materias = new MateriaRepository(_dataSource);
            Profesores = new ProfesorRepository(_dataSource);
        }

        public static IAlumnoRepository Alumnos { get; private set; }
        public static IMateriaRepository Materias { get; private set; }
        public static IProfesorRepository Profesores { get; private set; }
    }
}
