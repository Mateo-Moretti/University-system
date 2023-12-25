using SistemadeUniversidad.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeUniversidad.Contracts.Services
{
    public interface IProfesorService
    {
        void InscribirEnMaterias(Materia materia);
        List<Materia> ObtenerMateriasInscritas();
        bool CheckYaInscripto(Materia materia);
    }
}
