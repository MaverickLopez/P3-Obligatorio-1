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
    public record Nombre
    {
        public string Valor { get; init; }

        public Nombre(string valor)
        {
            Valor = valor;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Valor) || string.IsNullOrWhiteSpace(Valor))
            {
                throw new UsuarioException("El nombre es obligatorio");
            }
        }
    }
}
