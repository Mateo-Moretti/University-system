using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeUniversidad.Contracts.Models
{
    public class Materia 
    {
        public string nombre;
        public int id;
        private List<Alumno> listaAlumnosInscritos = new List<Alumno>();
        private List<Profesor> listaProfesoresInscritos = new List<Profesor>();

        public Materia(string nombre, int id)
        {          
            this.id = id;
            this.nombre = nombre;          
        }

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
        ////////////////////////////////////////
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
