using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeUniversidad.Contracts;

namespace SistemadeUniversidad.Contracts.Models
{
    public class Alumno : Persona
    {       
        public Alumno(string nombre, int id) : base (nombre , id)
        {

        }
      
    }
}
