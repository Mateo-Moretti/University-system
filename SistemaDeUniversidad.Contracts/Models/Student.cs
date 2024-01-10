using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeUniversidad.Contracts.Models;

namespace SistemadeUniversidad.Contracts.Models
{
    public class Student : Person
    {       
        public Student(string name, int? ID = null) : base(name, ID)
        {
            
        }
    }
}
