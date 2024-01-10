using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeUniversidad.Services
{
    public class StudentService : IStudentService
    {
        public Task<Student> CreateAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateAsync(int id, string name)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Student> CreateAsync(string name, int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetCoursesAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
