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
    public class BuscarEnvioNumeroTracking : IBuscarEnvioNumeroTracking
    {
        private IRepositorioEnvio RepoEnvio { get; set; }
        public BuscarEnvioNumeroTracking(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }
        public EnvioEnteroDTO Ejecutar(string numeroTracking)
        {
            return EnvioMapper.EnvioToEnvioEnteroDTO(RepoEnvio.GetEnvioPorNumeroTracking(numeroTracking));
        }
    }
}
