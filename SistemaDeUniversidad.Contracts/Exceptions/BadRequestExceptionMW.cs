using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeUniversidad.Contracts.Exceptions
{
    public class BadRequestExceptionMW : Exception
    {
        public string Message;

        public int Code { get; protected set; } = 400;

        public BadRequestExceptionMW(string message)
        {
            this.Message = message;
        }

        public BadRequestExceptionMW()
        {

        }
    }
}
