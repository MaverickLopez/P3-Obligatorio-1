using Compartido.DTOs.UsuarioDTOs;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.UsuarioCU;
using LogicaNegocio.InterfaceRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class BuscarUsuario : IBuscarUsuario
    {
        private IRepositorioUsuario repoUsuario {  get; set; }
        public BuscarUsuario(IRepositorioUsuario repoUsuario)
        {
            this.repoUsuario = repoUsuario;
        }

        public MostrarUsuarioDTO Ejecutar(int id)
        {
            return UsuarioMapper.UsuarioToMostrarUsuarioDTO(repoUsuario.GetPorId(id));
        }
    }
}
