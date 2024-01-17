using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.Contracts.Exceptions;
using SistemaDeUniversidad.Contracts.Services;
using SistemaDeUniversidad.Persistance;

namespace SistemaDeUniversidad.Services
{
    public class StudentService : IStudentService
    {
        private void ValidateStudent(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BadRequestExceptionMW();
            }
        }

        //GET ALL
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await DataBase.GetInstance().Students.GetAllAsync();
        }

        //GET
        public async Task<Student> GetByIdAsync(int id)
        {
            return await DataBase.GetInstance().Students.GetByIdAsync(id)
                 ?? throw new KeyNotFoundExceptionMW("Id does not exist");
        }

        //POST
        public async Task<Student> CreateAsync(string name)
        {
            ValidateStudent(name);

            Student Student = new Student(name);
            await DataBase.GetInstance().Students.CreateAsync(Student);

            return Student;
        }

        //PUT
        public async Task<Student> UpdateAsync(int id, string name)
        {
            ValidateStudent(name);

            Student student = await GetByIdAsync(id);

            student.Name = name;

            await DataBase.GetInstance().Students.UpdateAsync(student);

            return student;
        }

        //DELETE
        public async Task DeleteAsync(int id)
        {
            try
            {
                await DataBase.GetInstance().Students.DeleteAsync(id);
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

            IEnumerable<Course> courseList = await DataBase.GetInstance().Courses.GetByStudentAsync(id);

            return courseList;
        }
    }
}
