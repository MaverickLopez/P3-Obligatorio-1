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
    public class MostrarUsuario : IMostrarUsuario
    {
        private IRepositorioUsuario RepoUsuarios { get; set; }
        public MostrarUsuario(IRepositorioUsuario repoUsuarios)
        {
            RepoUsuarios = repoUsuarios;
        }

        public List<MostrarUsuarioDTO> Ejecutar()
        {
            List<Usuario> usuarios = RepoUsuarios.GetAll().ToList();
            if (usuarios.Count == 0)
            {
                throw new ArgumentNullException("No hay usuarios");
            }

            List<MostrarUsuarioDTO> usuariosDTO = UsuarioMapper.UsuarioDTOFromUsuario(usuarios);
        
            return usuariosDTO;
        }
    }
}
