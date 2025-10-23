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
    public record Email
    {
        public string Valor { get; init; }

        public Email(string valor)
        {
            Valor = valor;
            Validar();
        }

        private void Validar()
        {
            bool tArroba = false;
            bool tPunto = false;
            for (int i = 0; i < Valor.Length; i++)
            {
                if (Valor[i] == '@')
                    tArroba = true;
                if (Valor[i] == '.')
                    tPunto = true;
            }

            if (string.IsNullOrEmpty(Valor) || string.IsNullOrWhiteSpace(Valor))
            {
                throw new UsuarioException("El email es obligatorio");
            }

            if (tArroba != true || tPunto != true || Valor.Length < 5)
            {
                throw new UsuarioException("El email debe contener un arroba, un punto y minimo 5 caracteres");
            }
        }
    }
}
