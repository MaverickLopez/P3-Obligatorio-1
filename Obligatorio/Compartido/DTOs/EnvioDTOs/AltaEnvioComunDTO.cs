using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.EnvioDTOs
{
    public class AltaEnvioComunDTO
    {
        public string Email { get; set; }
        public int EmpleadoId { get; set; }
        public double Peso { get; set; }
        public int AgenciaId { get; set; }
    }
}
