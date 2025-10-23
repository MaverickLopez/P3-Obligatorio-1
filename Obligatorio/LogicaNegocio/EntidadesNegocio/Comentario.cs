using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Comentario : IEquatable<Comentario>
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEmpleado { get; set; }
        public string TextoComentario { get; set; }

        private Comentario() { }
        public Comentario(DateTime fecha, int idEmpleado, string textoComentario)
        {
            Fecha = fecha;
            IdEmpleado = idEmpleado;
            TextoComentario = textoComentario;
        }

        public bool Equals(Comentario? other)
        {
            return Id == other.Id;
        }
    }
}
