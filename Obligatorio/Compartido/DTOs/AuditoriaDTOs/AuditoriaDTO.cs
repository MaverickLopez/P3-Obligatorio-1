using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.AuditoriaDTOs
{
    public class AuditoriaDTO
    {
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEmpleado { get; set; }
    }
}
