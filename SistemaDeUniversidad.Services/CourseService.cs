using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.Contracts.Exceptions;
using SistemaDeUniversidad.Contracts.Services;
using SistemaDeUniversidad.Persistance;

namespace SistemaDeUniversidad.Services
{
    public class CourseService : ICourseService
    {
        private void ValidateCourse(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BadRequestExceptionMW();
            }
        }

        //GET ALL
        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await DataBase.GetInstance().Courses.GetAllAsync();
        }

        //GET
        public async Task<Course> GetByIdAsync(int id)
        {
            return await DataBase.GetInstance().Courses.GetByIdAsync(id)
                 ?? throw new KeyNotFoundExceptionMW("Id does not exist");
        }

        //POST
        public async Task<Course> CreateAsync(string name)
        {
            ValidateCourse(name);

            Course Course = new Course(name);
            await DataBase.GetInstance().Courses.CreateAsync(Course);

            return Course;
        }

        //PUT
        public async Task<Course> UpdateAsync(int id, string name)
        {
            ValidateCourse(name);

            Course course = await GetByIdAsync(id);

            course.Name = name;

            await DataBase.GetInstance().Courses.UpdateAsync(course);

            return course;
        }

        //DELETE
        public async Task DeleteAsync(int id)
        {
            try
            {
                await DataBase.GetInstance().Courses.DeleteAsync(id);
            }
            catch (InvalidOperationException)
            {
                throw new KeyNotFoundExceptionMW("Id does not exist");
            }
        }



        ///TODAVIA NO EN USO
        
         //Anotar alumnos
        public async Task EnrollStudentAsync(int studentId, int courseId)
        {
            await DataBase.GetInstance().Courses.EnrollStudentAsync(studentId, courseId);
        }

        //Anotar profesores
        public async Task EnrollProfessorAsync(int professorId, int courseId)
        {
            await DataBase.GetInstance().Courses.EnrollStudentAsync(professorId, courseId);
        }
        
        //Ver alumnos inscriptos
        public async Task<IEnumerable<Student>> GetStudentsAsync(int courseId)
        {
            return await DataBase.GetInstance().Students.GetByCourseAsync(courseId);
        }

        //Ver profesores inscriptos
        public async Task<IEnumerable<Profesor>> GetProfessorsAsync(int courseId)
        {
            return await DataBase.GetInstance().Profesors.GetByCourseAsync(courseId);
        }
        
    }
}
