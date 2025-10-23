using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.AgenciaDTOs
{
    public class AgenciaDTO
    {
        public string Nombre { get; set; }
        public string DireccionPostal { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
