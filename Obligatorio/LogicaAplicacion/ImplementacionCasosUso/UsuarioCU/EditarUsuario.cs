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
    public class EditarUsuario : IEditarUsuario
    {
        private IRepositorioUsuario repoUsuario {  get; set; }
        public EditarUsuario(IRepositorioUsuario repoUsuario)
        {
            this.repoUsuario = repoUsuario;
        }

        public void Ejecutar(MostrarUsuarioDTO usuarioDTO)
        {
            Usuario usuario = UsuarioMapper.UsuarioFromMostrarUsuarioDTO(usuarioDTO);
            usuario.Id = usuarioDTO.Id;
            repoUsuario.Editar(usuario);
        }
    }
}
