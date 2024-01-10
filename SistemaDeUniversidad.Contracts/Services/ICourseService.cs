using SistemadeUniversidad.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeUniversidad.Contracts.Services
{
    public interface ICourseService
    {
        Task<Course> CreateAsync(string name);

        Task<Course> UpdateAsync(int id, string name);

        Task DeleteAsync(int id);

        Task<Course> GetByIdAsync(int id);

        Task<IEnumerable<Course>> GetAllAsync();

        Task<IEnumerable<Student>> GetStudentsAsync(int id);

        Task<IEnumerable<Profesor>> GetProfessorsAsync(int id);
        Task EnrollStudentAsync(int studentId, int courseId);

        Task EnrollProfessorAsync(int professorId, int courseId);

    }
}
