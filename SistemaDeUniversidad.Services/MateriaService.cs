using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.Contracts.Repositories;
using SistemaDeUniversidad.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeUniversidad.Services
{
    public class MateriaService : IMateriaService
    {
        private List<Alumno> listaAlumnosInscritos = new List<Alumno>();
        private List<Profesor> listaProfesoresInscritos = new List<Profesor>();

        public void InscribirAlumno(Alumno alumno)
        {
            listaAlumnosInscritos.Add(alumno);
        }

        public void DesinscribirAlumnoDeMaterias(Alumno alumno)
        {
            listaAlumnosInscritos.Remove(alumno);
        }

        public List<Alumno> ObtenerAlumnosInscritos()
        {
            return listaAlumnosInscritos;
        }

        public void InscribirProfesor(Profesor profesor)
        {
            listaProfesoresInscritos.Add(profesor);
        }

        public List<Profesor> ObtenerProfesoresInscritos()
        {
            return listaProfesoresInscritos;
        }
    }
}
