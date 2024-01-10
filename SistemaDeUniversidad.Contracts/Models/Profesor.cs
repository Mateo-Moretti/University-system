using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeUniversidad.Contracts.Models;

namespace SistemadeUniversidad.Contracts.Models
{
    public class Profesor : Person
    {
        public Profesor(string Name, int? Id = null) : base(Name, Id)
        {

        }
    }
}
