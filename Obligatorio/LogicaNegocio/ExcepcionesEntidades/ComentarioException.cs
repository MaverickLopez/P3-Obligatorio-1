using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionesEntidades
{
    public class ComentarioException : Exception
    {
        public ComentarioException() { }

        public ComentarioException(string message) : base(message) { }

        public ComentarioException(string message, Exception innerException) : base(message, innerException) { }

    }
}
