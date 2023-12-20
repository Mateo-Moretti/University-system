using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeUniversidad.Contracts;

namespace SistemadeUniversidad.Contracts.Models
{
    public class Profesor : Persona
    {
        private List<Materia> listaMateriasInscritas = new List<Materia>();

        public Profesor(string nombre, int id) : base(nombre, id){}

        public void InscribirEnMaterias(Materia materia)
        {
            listaMateriasInscritas.Add(materia);
        }

        public List<Materia> ObtenerMateriasInscritas()
        {
            return listaMateriasInscritas;
        }

        public bool CheckYaInscripto(Materia materia)
        {
            if (listaMateriasInscritas.Contains(materia))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
