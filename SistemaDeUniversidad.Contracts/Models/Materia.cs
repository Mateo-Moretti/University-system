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
   
        public Materia(string nombre, int id)
        {          
            this.id = id;
            this.nombre = nombre;          
        }
    }
}
