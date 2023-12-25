using SistemadeUniversidad.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeUniversidad.Contracts.Services
{
    public interface IMateriaService
    {
        void InscribirAlumno(Alumno alumno);
        void DesinscribirAlumnoDeMaterias(Alumno alumno);
        List<Alumno> ObtenerAlumnosInscritos();
        void InscribirProfesor(Profesor profesor);
        List<Profesor> ObtenerProfesoresInscritos();
    }
}
