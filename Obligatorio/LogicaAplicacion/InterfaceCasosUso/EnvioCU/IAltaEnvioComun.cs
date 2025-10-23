using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compartido.DTOs.EnvioDTOs;

namespace LogicaAplicacion.InterfaceCasosUso.EnvioCU
{
    public interface IAltaEnvioComun
    {
        int Ejecutar(AltaEnvioComunDTO envioDTO);
    }
}
