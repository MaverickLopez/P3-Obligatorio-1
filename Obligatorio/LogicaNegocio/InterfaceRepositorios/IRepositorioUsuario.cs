using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfaceRepositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        public Usuario Login(string nombre, string contrasenia);
        public Usuario GetByEmailUsuario(string email);
    }
}
