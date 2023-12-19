using SistemadeUniversidad.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeUniversidad.Contracts.Repositories
{
    public interface IAlumnoRepository
    {
        Task CreateAsync(Alumno alumno, string nombre, int id);
        Task InscribirAMateria(int idAlumno, int idMateria);
    }
}
