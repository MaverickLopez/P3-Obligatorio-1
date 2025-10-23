using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject.Usuario
{
    [ComplexType]
    public record Contrasenia
    {
        public string Valor { get; init; }

        public Contrasenia(string valor)
        {
            Valor = valor;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Valor) || string.IsNullOrWhiteSpace(Valor))
            {
                throw new UsuarioException("El contrasenia es obligatoria");
            }

            if (Valor.Length < 8)
            {
                throw new UsuarioException("La contrasenia debe minimo tener 8 caracteres");
            }
        }
    }
}
