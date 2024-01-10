using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.Contracts.Services;
using SistemaDeUniversidad.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeUniversidad.Services
{
    public class ProfesorService : IProfesorService
    {

        private async Task ValidateStudentAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be empty");
            }
        }

        public async Task<Profesor> CreateAsync(string name)
        {
            await ValidateStudentAsync(name);
            Profesor Professor = new Profesor(name);
            await DataBase.GetInstance().Profesors.CreateAsync(Professor);

            return Professor;
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await DataBase.GetInstance().Profesors.DeleteAsync(id);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException("Id does not exist");
            }
        }

        public async Task<IEnumerable<Profesor>> GetAllAsync()
        {
            return await DataBase.GetInstance().Profesors.GetAllAsync();
        }

        public async Task<Profesor> GetByIdAsync(int id)
        {
            return await DataBase.GetInstance().Profesors.GetByIdAsync(id)
                 ?? throw new KeyNotFoundException("The Id does not correspond to any professor");
        }

        public async Task<Profesor> UpdateAsync(int id, string name)
        {
            Profesor professor = await GetByIdAsync(id);

            await ValidateStudentAsync(name);

            professor.Name = name;

            await DataBase.GetInstance().Profesors.UpdateAsync(professor);

            return professor;
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync(int id)
        {
            if (!await DataBase.GetInstance().Courses.ExistsByIdAsync(id))
            {
                throw new KeyNotFoundException("The Id does not correspond to any course");
            }

            IEnumerable<Course> courseList = await DataBase.GetInstance().Courses.GetByProfesorAsync(id);

            return courseList;

        }
    }
}
