using Compartido.DTOs.EnvioDTOs;
using Compartido.DTOs.UsuarioDTOs;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class EnvioMapper
    {
        public static Envio EnvioFromEnvioComunDTO(AltaEnvioComunDTO envioDTO,
            Usuario usu, Agencia age)
        {
            if (envioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }

            Envio ret = new Comun(envioDTO.EmpleadoId, usu.Id, envioDTO.Peso, age);

            return ret;
        }

        public static Envio EnvioFromEnvioUrgenteDTO(AltaEnvioUrgenteDTO envioDTO,
            Usuario usu)
        {
            if (envioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }

            Envio ret = new Urgente(envioDTO.EmpleadoId, usu.Id, envioDTO.Peso, envioDTO.DireccionPostal, null, false);

            return ret;
        }

        public static List<EnvioEnteroDTO> EnvioDTOFromEnvio(List<Envio> envios)
        {
            List<EnvioEnteroDTO> mostrarEnviosDTO = new List<EnvioEnteroDTO>();

            foreach (Envio e in envios)
            {
                EnvioEnteroDTO mostrarEnvioDTO = new EnvioEnteroDTO()
                {
                    Id = e.Id,
                    NumeroTracking = e.NumeroTracking,
                    EmpleadoId = e.IdEmpleado,
                    ClienteId = e.IdCliente,
                    Peso = e.Peso,
                    Estado = e.Estado,
                    Comentarios = e.Comentario
                };

                if (mostrarEnvioDTO.Estado == Estado.EN_PROCESO)
                {
                    mostrarEnviosDTO.Add(mostrarEnvioDTO);
                }

            }
            return mostrarEnviosDTO;
        }

        public static EnvioEnteroDTO EnvioToEnvioEnteroDTO(Envio envio)
        {
            EnvioEnteroDTO envioDTO = new EnvioEnteroDTO()
            {
                Id = envio.Id,
                NumeroTracking = envio.NumeroTracking,
                EmpleadoId = envio.IdEmpleado,
                ClienteId = envio.IdCliente,
                Peso = envio.Peso,
                Estado = envio.Estado,
                Comentarios = envio.Comentario
            };
            return envioDTO;
        }
    }
}
