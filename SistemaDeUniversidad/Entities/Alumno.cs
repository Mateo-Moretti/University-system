using SistemaDeUniversidad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeUniversidad.Entities
{
    public class Alumno : Persona
    {       
        private List<Materia> listaMateriasInscritas = new List<Materia>();


        public Alumno(string nombre, int id) : base (nombre , id)
        {
           
        }
      
        public void InscribirEnMaterias(Materia materia)
        {
            listaMateriasInscritas.Add(materia);
            
        }

        public List<Materia> ObtenerMateriasInscritas()
        {
            return listaMateriasInscritas;
        }

    }
}
