using Compartido.DTOs.ComentarioDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCasosUso.ComentarioCU
{
    public interface IAltaComentario
    {
        void Ejecutar(ComentarioDTO comentarioDTO);
    }
}
