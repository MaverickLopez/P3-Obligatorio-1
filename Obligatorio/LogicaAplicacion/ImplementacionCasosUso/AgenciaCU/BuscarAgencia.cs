using Compartido.DTOs.AgenciaDTOs;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.AgenciaCU;
using LogicaNegocio.InterfaceRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.AgenciaCU
{
    public class BuscarAgencia : IBuscarAgencia
    {
        private IRepositorioAgencia repoAgencia { get; set; }
        public BuscarAgencia(IRepositorioAgencia repoAgencia)
        {
            this.repoAgencia = repoAgencia;
        }

        public AgenciaEnteraDTO Ejecutar(int id)
        {
            return AgenciaMapper.AgenciaToAgenciaEnteraDTO(repoAgencia.GetPorId(id));
        }
    }
}
