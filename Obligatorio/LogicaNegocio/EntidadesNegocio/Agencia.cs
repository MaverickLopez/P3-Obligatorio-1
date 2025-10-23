using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObject.Agencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Agencia : IEquatable<Agencia>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DireccionPostal DireccionPostal { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }

        private Agencia() { }
        public Agencia(string nombre, string direccionPostal, double latitud, double longitud)
        {
            Nombre = nombre;
            DireccionPostal = new DireccionPostal(direccionPostal);
            Latitud = latitud;
            Longitud = longitud;
            Validar();
        }
        private void Validar()
        {
            if (string.IsNullOrEmpty(Nombre)
                || string.IsNullOrWhiteSpace(Nombre)
                || string.IsNullOrEmpty(DireccionPostal.Valor)
                || string.IsNullOrWhiteSpace(DireccionPostal.Valor)
                || Latitud == 0
                || Longitud == 0
                )
            {
                throw new AgenciaExcepction("No pueden haber datos vacios");
            }
        }
        public bool Equals(Agencia? other)
        {
            return Id == other.Id;
        }
    }
}
