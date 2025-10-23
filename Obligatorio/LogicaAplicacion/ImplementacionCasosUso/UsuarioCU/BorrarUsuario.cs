using LogicaAplicacion.InterfaceCasosUso.UsuarioCU;
using LogicaNegocio.InterfaceRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.UsuarioCU
{
    public class BorrarUsuario : IBorrarUsuario
    {
        private IRepositorioUsuario repoUsuarios { get; set; }
        public BorrarUsuario(IRepositorioUsuario repositorioUsuarios)
        {
            repoUsuarios = repositorioUsuarios;
        }

        public void Ejecutar(int id)
        {
            repoUsuarios.Baja(id);
        }
    }
}
