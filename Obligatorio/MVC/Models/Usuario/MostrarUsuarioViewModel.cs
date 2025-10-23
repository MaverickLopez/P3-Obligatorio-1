using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models.Usuario
{
    public class MostrarUsuarioViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public Rol Rol { get; set; }
        public bool Estado { get; set; }
    }
}
