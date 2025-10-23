using LogicaNegocio.EntidadesNegocio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Models.Usuario
{
    public class UsuarioViewModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public Rol Rol { get; set; }

    }
}
