using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.EnvioDTOs
{
    public class AltaEnvioUrgenteDTO
    {
        public string Email { get; set; }
        public int EmpleadoId { get; set; }
        public string DireccionPostal { get; set; }
        public double Peso { get; set; }
    }
}
