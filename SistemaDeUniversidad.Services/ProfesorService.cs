using SistemadeUniversidad.Contracts.Models;
using SistemaDeUniversidad.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeUniversidad.Services
{
    public class ProfesorService : IProfesorService
    {
        private List<Materia> listaMateriasInscritas = new List<Materia>();

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
