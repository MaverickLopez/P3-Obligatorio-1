using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Urgente : Envio
    {
        public string DireccionPostal { get; set; }
        public TimeSpan? TiempoEntrega { get; set; }
        public bool Eficiencia { get; set; }

        protected Urgente() : base() { }

        public Urgente(int idEmpleado, int idCliente, double peso, string direccionPostal, TimeSpan? tiempoEntrega, bool eficiencia) : base(idEmpleado, idCliente, peso)
        {
            DireccionPostal = direccionPostal;
            TiempoEntrega = tiempoEntrega;
            Eficiencia = eficiencia;
        }

        public override void CalcularTiempoEntrega()
        {
            DateTime ingreso = DateTime.Now;
            DateTime finalizado = DateTime.Now;
            foreach (Comentario c in Comentario)
            {
                if (c.TextoComentario == "Ingresado en agencia de origen")
                {
                    ingreso = c.Fecha;
                }
                else if (c.TextoComentario == "Finalizado")
                {
                    finalizado = c.Fecha;
                }
            }

            TiempoEntrega = finalizado - ingreso;

            if (TiempoEntrega < new TimeSpan(24, 0, 0))
            {
                Eficiencia = true;
            }
            else
            {
                Eficiencia = false;
            }
        }

    }
}
