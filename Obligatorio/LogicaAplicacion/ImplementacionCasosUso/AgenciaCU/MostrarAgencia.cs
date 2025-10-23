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
    public class MostrarAgencia : IMostrarAgencia
    {
        private IRepositorioAgencia RepoAgencias { get; set; }
        public MostrarAgencia(IRepositorioAgencia repoAgencias)
        {
            RepoAgencias = repoAgencias;
        }

        public List<AgenciaEnteraDTO> Ejecutar()
        {
            List<Agencia> agencias = RepoAgencias.GetAll().ToList();
            if (agencias == null)
            {
                throw new ArgumentNullException("No hay agencias");
            }

            List<AgenciaEnteraDTO> ret = AgenciaMapper.ListAgenciaEnteraDTOFromListAgencia(agencias);
            return ret;
        }
    }
}
