using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeUniversidad.Contracts.Repositories;
using SistemaDeUniversidad.Persistance.Repositories;
using Npgsql;

namespace SistemaDeUniversidad.Persistance
{
    public static class DataBase
    {
        private static readonly NpgsqlDataSource _dataSource;

        static DataBase()
        {
            _dataSource = NpgsqlDataSource.Create("Host=127.0.0.1;Username=postgres;Password=2007;Database=postgres");
        }
    }
}
