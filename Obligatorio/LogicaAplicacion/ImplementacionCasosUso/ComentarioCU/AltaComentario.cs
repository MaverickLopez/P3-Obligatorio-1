using Compartido.DTOs.ComentarioDTOs;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.ComentarioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfaceRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.ComentarioCU
{
    public class AltaComentario : IAltaComentario
    {
        private IRepositorioEnvio RepoEnvio { get; set; }
        public AltaComentario(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }

        public void Ejecutar(ComentarioDTO comentarioDTO)
        {
            if (comentarioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            Comentario comentario = ComentarioMapper.ComentarioFromComentarioDTO(comentarioDTO);
            RepoEnvio.AltaComentario(comentarioDTO.EnvioId, comentario);
        }
    }
}
