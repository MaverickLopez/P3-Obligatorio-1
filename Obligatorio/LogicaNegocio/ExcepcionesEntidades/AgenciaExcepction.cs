using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ExcepcionesEntidades
{
    public class AgenciaExcepction : Exception
    {
        public AgenciaExcepction() { }

        public AgenciaExcepction(string message) : base(message) { }

        public AgenciaExcepction(string message, Exception innerException) : base(message, innerException) { }
    }
}
