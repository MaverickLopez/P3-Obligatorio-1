using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Comun : Envio
    {
        public Agencia Agencia { get; set; }

        protected Comun():base() { }

        public Comun(int idEmpleado, int idCliente, double peso, Agencia agencia) : base(idEmpleado, idCliente, peso)
        {
            Agencia = agencia;
        }

        public override void CalcularTiempoEntrega()
        {
        }

    }
}
