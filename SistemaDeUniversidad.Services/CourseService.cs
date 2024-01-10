using SistemadeUniversidad.Contracts.Models;
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
                throw new ArgumentNullException("Name cannot be empty");
            }
        }

        private async Task ExistsByIdOrThrowAsync(int id)
        {
            if (!await DataBase.GetInstance().Courses.ExistsByIdAsync(id))
            {
                throw new KeyNotFoundException("The Id does not correspond to any course");
            }
        }

        public async Task<Course> CreateAsync(string name)
        {
            ValidateCourse(name);
            Course Course = new Course(name);
            await DataBase.GetInstance().Courses.CreateAsync(Course);

            return Course;
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await DataBase.GetInstance().Courses.DeleteAsync(id);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException("Id does not exist");
            }
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await DataBase.GetInstance().Courses.GetAllAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await DataBase.GetInstance().Courses.GetByIdAsync(id)
                 ?? throw new KeyNotFoundException("The Id does not correspond to any course");
        }

        public async Task<Course> UpdateAsync(int id, string name)
        {
            ValidateCourse(name);

            Course course = await GetByIdAsync(id);

            course.Name = name;

            await DataBase.GetInstance().Courses.UpdateAsync(course);

            return course;
        }

        public async Task EnrollStudentAsync(int studentId, int courseId)
        {
            await ExistsByIdOrThrowAsync(courseId);

            if (!await DataBase.GetInstance().Students.ExistsByIdAsync(studentId))
            {
                throw new KeyNotFoundException("The Id does not correspond to any student");
            }

            await DataBase.GetInstance().Courses.EnrollStudentAsync(studentId, courseId);
        }

        public async Task EnrollProfessorAsync(int professorId, int courseId)
        {
            await ExistsByIdOrThrowAsync(courseId);

            if (!await DataBase.GetInstance().Profesors.ExistsByIdAsync(professorId))
            {
                throw new KeyNotFoundException("Id does not correspond to any professor");
            }

            await DataBase.GetInstance().Courses.EnrollStudentAsync(professorId, courseId);
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync(int courseId)
        {
            await ExistsByIdOrThrowAsync(courseId);

            return await DataBase.GetInstance().Students.GetByCourseAsync(courseId);
        }

        public async Task<IEnumerable<Profesor>> GetProfessorsAsync(int courseId)
        {
            return await DataBase.GetInstance().Profesors.GetByCourseAsync(courseId);
        }

    }
}
