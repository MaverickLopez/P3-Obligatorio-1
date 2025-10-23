using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObject.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Usuario : IEquatable<Usuario>
    {
        public int Id { get; set; }
        public Nombre Nombre { get; set; }
        public string Apellido { get; set; }
        public Email Email { get; set; }
        public Contrasenia Contrasenia { get; set; }
        public Rol Rol { get; set; }
        public bool Estado { get; set; }

        private Usuario() { }
        public Usuario(string nombre, string apellido, string email, string contrasenia, Rol rol)
        {
            Nombre = new Nombre(nombre);
            Apellido = apellido;
            Email = new Email(email);
            Contrasenia = new Contrasenia(contrasenia);
            Rol = rol;
            Estado = true;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Apellido) || string.IsNullOrWhiteSpace(Apellido))
            {
                throw new UsuarioException("No pueden haber datos vacios");
            }
        }

        public bool Equals(Usuario? other)
        {
            return Id == other.Id;
        }
    }
}
