using Compartido.DTOs.AgenciaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCasosUso.AgenciaCU
{
    public interface IBuscarAgencia
    {
        public AgenciaEnteraDTO Ejecutar(int id);
    }
}
