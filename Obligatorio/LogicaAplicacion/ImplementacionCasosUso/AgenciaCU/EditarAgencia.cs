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
    public class EditarAgencia : IEditarAgencia
    {
        private IRepositorioAgencia repoAgencia { get; set; }
        public EditarAgencia(IRepositorioAgencia repoAgencia)
        {
            this.repoAgencia = repoAgencia;
        }

        public void Ejecutar(AgenciaEnteraDTO agenciaDTO)
        {
            Agencia agencia = AgenciaMapper.AgenciaFromAgenciaEnteraDTO(agenciaDTO);
            agencia.Id = agenciaDTO.Id;
            repoAgencia.Editar(agencia);
        }
    }
}
