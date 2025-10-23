using Compartido.DTOs.UsuarioDTOs;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.UsuarioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfaceRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class AltaUsuario : IAltaUsuario
    {
        private IRepositorioUsuario RepoUsuarios { get; set; }

        public AltaUsuario(IRepositorioUsuario repoUsuarios)
        {
            RepoUsuarios = repoUsuarios;
        }

        public void Ejecutar(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            //Convertir el DTO a objeto de tipo entidad Carrera
            Usuario usuario = UsuarioMapper.UsuarioFromUsuarioDTO(usuarioDTO);
            //Pasar este objeto Carrera a LogicaAccesoDatos
            RepoUsuarios.Alta(usuario);
        }
    }
}
