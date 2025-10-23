using Compartido.DTOs.EnvioDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCasosUso.EnvioCU
{
    public interface IBuscarEnvioNumeroTracking
    {
        EnvioEnteroDTO Ejecutar(string numeroTracking);
    }
}
