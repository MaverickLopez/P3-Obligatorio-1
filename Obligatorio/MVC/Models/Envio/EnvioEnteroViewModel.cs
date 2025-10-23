using LogicaNegocio.EntidadesNegocio;

namespace MVC.Models.Envio
{
    public class EnvioEnteroViewModel
    {
        public int Id { get; set; }
        public string NumeroTracking { get; set; }
        public int EmpleadoId { get; set; }
        public int ClienteId { get; set; }
        public double Peso {  get; set; }
        public Estado Estado { get; set; }
    }
}
