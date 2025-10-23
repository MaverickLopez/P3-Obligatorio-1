using Compartido.DTOs.AgenciaDTOs;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.AgenciaCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfaceRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.AgenciaCU
{
    public class AltaAgencia : IAltaAgencia
    {
        private IRepositorioAgencia RepoAgencias { get; set; }
        public AltaAgencia(IRepositorioAgencia repoAgencias)
        {
            RepoAgencias = repoAgencias;
        }

        public void Ejecutar(AgenciaDTO agenciaDTO)
        {
            if (agenciaDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }

            Agencia agencia = AgenciaMapper.AgenciaFromAgenciaDTO(agenciaDTO);
            RepoAgencias.Alta(agencia);
        }
    }
}
