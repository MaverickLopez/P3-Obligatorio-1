using Compartido.DTOs.ComentarioDTOs;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class ComentarioMapper
    {
        public static Comentario ComentarioFromComentarioDTO(ComentarioDTO comentarioDTO)
        {
            if (comentarioDTO == null)
            {
                throw new ArgumentException("Datos incorrectos");
            }
            return new Comentario(comentarioDTO.Fecha, comentarioDTO.EmpleadoId, comentarioDTO.TextoComentario);
        }


    }
}
