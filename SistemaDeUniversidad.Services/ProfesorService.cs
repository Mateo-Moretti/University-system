using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.Contracts.Exceptions;
using SistemaDeUniversidad.Contracts.Services;
using SistemaDeUniversidad.Persistance;

namespace SistemaDeUniversidad.Services
{
    public class ProfesorService : IProfesorService
    {

        private void ValidateProfesor(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BadRequestExceptionMW();
            }
        }

        //GET ALL
        public async Task<IEnumerable<Profesor>> GetAllAsync()
        {
            return await DataBase.GetInstance().Profesors.GetAllAsync();
        }

        //GET 
        public async Task<Profesor> GetByIdAsync(int id)
        {
            return await DataBase.GetInstance().Profesors.GetByIdAsync(id)
                 ?? throw new KeyNotFoundExceptionMW("Id does not exist");
        }

        //POST
        public async Task<Profesor> CreateAsync(string name)
        {
            ValidateProfesor(name);

            Profesor Professor = new Profesor(name);
            await DataBase.GetInstance().Profesors.CreateAsync(Professor);

            return Professor;
        }

        //PUT
        public async Task<Profesor> UpdateAsync(int id, string name)
        {
            ValidateProfesor(name);

            Profesor professor = await GetByIdAsync(id);

            professor.Name = name;

            await DataBase.GetInstance().Profesors.UpdateAsync(professor);

            return professor;
        }

        //DELETE
        public async Task DeleteAsync(int id)
        {
            try
            {
                await DataBase.GetInstance().Profesors.DeleteAsync(id);
            }
            catch (InvalidOperationException)
            {
                throw new KeyNotFoundExceptionMW("Id does not exist");
            }
        }


        //TODAVIA NO EN USO

        //Ver cursos inscriptos
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
