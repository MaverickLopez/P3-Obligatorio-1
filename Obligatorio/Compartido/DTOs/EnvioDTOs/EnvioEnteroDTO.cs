using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.EnvioDTOs
{
    public class EnvioEnteroDTO
    {
        public int Id { get; set; }
        public string NumeroTracking { get; set; }
        public int EmpleadoId { get; set; }
        public int ClienteId { get; set; }
        public double Peso { get; set; }
        public Estado Estado { get; set; }
        public List<Comentario> Comentarios { get; set; }

    }
}
