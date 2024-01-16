using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeUniversidad.Contracts.Exceptions
{
    public class KeyNotFoundExceptionMW : Exception
    {
        public int Code { get; protected set; } = 404;
    }
}
