using Npgsql;
using SistemaDeUniversidad.Contracts.Repositories;

namespace SistemaDeUniversidad.Persistance.Repositories
{
    internal abstract class BaseRepository<T> : IRepository<T>
    {
        private NpgsqlDataSource _dataSource;

        public BaseRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }


        public abstract Task CreateAsync(T entity); 

        public abstract Task DeleteAsync(int id);

        public abstract Task<IEnumerable<T>> GetAllAsync();

        public abstract Task<T?> GetByIdAsync(int id);

        public abstract Task UpdateAsync(T entity);

        protected abstract T MapRowToModel(NpgsqlDataReader reader);

        protected async Task<int> ExecuteNonQueryAsync(string query, object[]? parameters = null)
        {
            using (NpgsqlCommand command = _dataSource.CreateCommand(query))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters.Select(p => new NpgsqlParameter(null, p)).ToArray());
                }

                int rowsAffected = await command.ExecuteNonQueryAsync();
                if (rowsAffected == 0)
                {
                    throw new InvalidOperationException("Can not excecute query");
                }

                return rowsAffected;
            }
        }

        protected async Task<RetType> ExecuteScalarAsync<RetType>(string query, object[]? parameters = null)
        {
            using (NpgsqlCommand command = _dataSource.CreateCommand(query))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters.Select(p => new NpgsqlParameter(null, p)).ToArray());
                }

                object? scalar = await command.ExecuteScalarAsync();

                if (scalar == null)
                {
                    throw new Exception("Can not excecute query");
                }

                return (RetType)scalar;
            }
        }

        protected async Task<int> ExecuteScalarIntAsync(string query, object[] parameters)
        {
            return await ExecuteScalarAsync<int>(query, parameters);
        }

        protected async Task<NpgsqlDataReader> GetQueryReaderAsync(string query, object[]? parameters = null)
        {
            using (NpgsqlCommand command = _dataSource.CreateCommand(query))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters.Select(p => new NpgsqlParameter(null, p)).ToArray());
                }

                return await command.ExecuteReaderAsync();
            }
        }
    }
}
