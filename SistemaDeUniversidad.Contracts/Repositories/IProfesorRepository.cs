using SistemadeUniversidad.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaDeUniversidad.Contracts.Repositories
{
    public interface IProfesorRepository : IRepository<Profesor>
    {
        Task<bool> ExistsByIdAsync(int id);

        Task<List<Profesor>> GetByCourseAsync(int courseID);
    }
}
