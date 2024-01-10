using SistemadeUniversidad.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeUniversidad.Contracts.Services
{
    public interface IProfesorService
    {
        Task<Profesor> CreateAsync(string name);

        Task<Profesor> UpdateAsync(int id, string name);

        Task DeleteAsync(int id);

        Task<Profesor> GetByIdAsync(int id);

        Task<IEnumerable<Profesor>> GetAllAsync();

        Task<IEnumerable<Course>> GetCoursesAsync(int id);

    }
}
