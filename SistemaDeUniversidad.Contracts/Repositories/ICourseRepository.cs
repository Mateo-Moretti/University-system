using SistemadeUniversidad.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaDeUniversidad.Contracts.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        public Task<List<Course>> GetByNameAsync(string name);

        Task<List<Course>> GetByStudentAsync(int studentID);

        Task<List<Course>> GetByProfesorAsync(int professorId);

        Task<bool> ExistsByIdAsync(int id);

        Task EnrollStudentAsync(int studentId, int courseId);

        Task EnrollProfesorAsync(int professorId, int courseId);

        Task RemoveProfesorAsync(int professorId, int courseId);

        Task RemoveStudentAsync(int studentId, int courseId);
    }
}
