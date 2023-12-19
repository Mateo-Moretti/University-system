using SistemadeUniversidad.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaDeUniversidad.Contracts.Repositories
{
    public interface IProfesorRepository
    {
        Task CreateAsync(Profesor profesor, string nombre, int id);
        Task InscribirAMateria(int idProfesor, int idMateria);
    }
}
