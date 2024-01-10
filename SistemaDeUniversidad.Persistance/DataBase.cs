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
    public  class DataBase : IDisposable
    {
        private static DataBase? instance = null;
        private readonly NpgsqlDataSource _dataSource;
        public IStudentRepository Students { get; private set; }
        public ICourseRepository Courses { get; private set; }
        public IProfesorRepository Profesors { get; private set; }

        private DataBase()
        {
            _dataSource = NpgsqlDataSource.Create("Host=127.0.0.1;Username=postgres;Password=2007;Database=postgres");
            Students = new StudentRepository(_dataSource);
            Courses = new CourseRepository(_dataSource);
            Profesors = new ProfesorRepository(_dataSource);
        }

        public void Dispose()
        {
            _dataSource.Dispose();
        }

        public static DataBase GetInstance()
        {
            if (instance == null)
            {
                instance = new DataBase();
            }

            return instance;
        }
    }
}
