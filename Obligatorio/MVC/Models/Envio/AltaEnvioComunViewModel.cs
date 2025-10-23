using MVC.Models.Agencia;
using System.Collections;

namespace MVC.Models.Envio
{
    public class AltaEnvioComunViewModel
    {
        public string Email { get; set; }
        public int AgenciaId { get; set; }
        public double Peso { get; set; }
        public IEnumerable<MostrarAgenciaViewModel> Agencias { get; set; } = new List<MostrarAgenciaViewModel>();
    }
}
