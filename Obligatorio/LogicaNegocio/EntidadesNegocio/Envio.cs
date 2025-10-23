using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public abstract class Envio : IEquatable<Envio>
    {
        private static int _ultimoTracking = 120;
        public int Id { get; set; }
        public string NumeroTracking { get; set; }

        public Usuario Empleado { get; set; }
        [ForeignKey("Empleado")]
        public int IdEmpleado { get; set; }

        public Usuario Cliente { get; set; }
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }

        public double Peso { get; set; }
        public Estado Estado { get; set; }
        public List<Comentario> Comentario { get; set; } = new List<Comentario>();

        protected Envio()
        {
            NumeroTracking = _ultimoTracking.ToString();
            Estado = Estado.EN_PROCESO;
            _ultimoTracking += _ultimoTracking / 3;
        }

        public Envio(int idEmpleado, int idCliente, double peso)
        {
            NumeroTracking = _ultimoTracking.ToString();
            IdEmpleado = idEmpleado;
            IdCliente = idCliente;
            Peso = peso;
            Estado = Estado.EN_PROCESO;
            _ultimoTracking += _ultimoTracking / 3;
        }

        public bool Equals(Envio? other)
        {
            return Id == other.Id;
        }

        public abstract void CalcularTiempoEntrega();



    }
}
