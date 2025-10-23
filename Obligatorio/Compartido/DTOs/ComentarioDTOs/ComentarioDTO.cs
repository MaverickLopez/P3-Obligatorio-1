using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.ComentarioDTOs
{
    public class ComentarioDTO
    {
        public int EnvioId { get; set; }
        public DateTime Fecha { get; set; }
        public int EmpleadoId { get; set; }
        public string TextoComentario { get; set; }
    }
}
