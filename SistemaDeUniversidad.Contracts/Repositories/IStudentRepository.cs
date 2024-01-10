using SistemadeUniversidad.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeUniversidad.Contracts.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {

        Task<List<Student>> GetByCourseAsync(int courseId);

        Task<bool> ExistsByIdAsync(int id);

        Task<int> GetAmountOfCorsesEnrolled(Student student);
    }
}
