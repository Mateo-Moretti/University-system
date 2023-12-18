using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeUniversidad.Contracts
{
    public abstract class Persona
    {
        public string nombre;
        public int id;

        public Persona(string nombre, int id)
        {
            this.nombre = nombre;
            this.id = id;
        }
    }
}
