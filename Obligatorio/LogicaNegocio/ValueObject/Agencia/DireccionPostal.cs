using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject.Agencia
{
    [ComplexType]
    public record DireccionPostal
    {
        public string Valor { get; init; }

        public DireccionPostal(string valor)
        {
            Valor = valor;
            Validar();
        }

        private void Validar()
        {
            bool tieneLetra = false;
            for (int i = 0; i < Valor.Length; i++)
            {
                if (!char.IsLetterOrDigit(Valor[i]) && Valor[i] != ' ')
                    tieneLetra = true; // Si encuentra un carácter no permitido
            }

            if (string.IsNullOrEmpty(Valor))
            {
                throw new AgenciaExcepction("La direccion postal es obligatoria");
            }
            if (Valor.Length != 5)
            {
                throw new AgenciaExcepction("La direccion postal debe poseer solo 5 digitos");
            }
            if (tieneLetra == true)
            {
                throw new AgenciaExcepction("La direccion postal debe poseer numeros");
            }
        }
    }
}
