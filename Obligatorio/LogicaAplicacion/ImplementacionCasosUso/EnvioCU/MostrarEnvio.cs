using Compartido.DTOs.EnvioDTOs;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.EnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfaceRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class MostrarEnvio : IMostrarEnvio
    {
        private IRepositorioEnvio RepoEnvio { get; set; }

        public MostrarEnvio(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }

        public List<EnvioEnteroDTO> Ejecutar()
        {
            List<Envio> envios = RepoEnvio.GetAll().ToList();
            if (envios == null)
            {
                throw new ArgumentException("No hay envios");
            }

            List<EnvioEnteroDTO> enviosDTO = EnvioMapper.EnvioDTOFromEnvio(envios);
            return enviosDTO;
        }
    }
}
