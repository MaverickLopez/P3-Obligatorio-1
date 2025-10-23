using Compartido.DTOs.AgenciaDTOs;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class AgenciaMapper
    {
        public static List<AgenciaEnteraDTO> ListAgenciaEnteraDTOFromListAgencia(List<Agencia> agencias)
        {
            List<AgenciaEnteraDTO> ret = new List<AgenciaEnteraDTO>();

            foreach (Agencia a in agencias)
            {
                AgenciaEnteraDTO agenciaDTO = new AgenciaEnteraDTO()
                {
                    Id = a.Id,
                    Nombre = a.Nombre,
                    DireccionPostal = a.DireccionPostal.Valor,
                    Latitud = a.Latitud,
                    Longitud = a.Longitud
                };
                ret.Add(agenciaDTO);
            }

            return ret;
        }

        public static Agencia AgenciaFromAgenciaDTO(AgenciaDTO agenciaDTO)
        {
            if (agenciaDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            return new Agencia(agenciaDTO.Nombre, agenciaDTO.DireccionPostal, agenciaDTO.Latitud, agenciaDTO.Longitud);
        }

        public static AgenciaEnteraDTO AgenciaToAgenciaEnteraDTO(Agencia agencia)
        {
            if (agencia == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            AgenciaEnteraDTO agenciaDTO = new AgenciaEnteraDTO()
            {
                Id = agencia.Id,
                Nombre = agencia.Nombre,
                DireccionPostal = agencia.DireccionPostal.Valor,
                Latitud = agencia.Latitud,
                Longitud = agencia.Longitud
            };

            return agenciaDTO;
        }

        public static Agencia AgenciaFromAgenciaEnteraDTO(AgenciaEnteraDTO agenciaDTO)
        {
            if (agenciaDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }

            return new Agencia(agenciaDTO.Nombre, agenciaDTO.DireccionPostal, agenciaDTO.Latitud, agenciaDTO.Longitud);
        }
    }
}
