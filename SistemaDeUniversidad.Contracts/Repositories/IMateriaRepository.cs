using SistemadeUniversidad.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaDeUniversidad.Contracts.Repositories
{
    public interface IMateriaRepository
    {
        Task CreateAsync(Materia materia, string nombre, int id);
        //Task InscribirAlumno(int idAlumno, int idMateria);
        //Task InscribirProfesor(int idProfesor, int idMateria);
        //Task DesinscribirDeAlumnoDeMateria(int idAlumno, int idMateria);
    }
}
