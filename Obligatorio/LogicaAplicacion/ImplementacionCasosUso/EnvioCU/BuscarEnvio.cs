using Compartido.DTOs.EnvioDTOs;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.EnvioCU;
using LogicaNegocio.InterfaceRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class BuscarEnvio : IBuscarEnvio
    {
        private IRepositorioEnvio RepoEnvio { get; set; }
        public BuscarEnvio(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }

        public EnvioEnteroDTO Ejecutar(int id)
        {
            return EnvioMapper.EnvioToEnvioEnteroDTO(RepoEnvio.GetPorId(id));
        }
    }
}
