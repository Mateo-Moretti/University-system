using SistemadeUniversidad.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeUniversidad.Contracts.Services
{
    public interface IStudentService
    {
        Task<Student> CreateAsync(string name);

        Task<Student> UpdateAsync(int id, string name);

        Task DeleteAsync(int id);

        Task<Student> GetByIdAsync(int id);

        Task<IEnumerable<Student>> GetAllAsync();

        Task<IEnumerable<Course>> GetCoursesAsync(int id);
    }
}
