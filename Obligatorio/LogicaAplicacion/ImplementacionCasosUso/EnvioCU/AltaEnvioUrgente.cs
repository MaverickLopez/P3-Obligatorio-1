using Compartido.DTOs.EnvioDTOs;
using Compartido.Mappers;
using LogicaAplicacion.InterfaceCasosUso.EnvioCU;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfaceRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class AltaEnvioUrgente : IAltaEnvioUrgente
    {
        private IRepositorioEnvio RepoEnvio { get; set; }
        private IRepositorioUsuario RepoUsuario { get; set; }
        public AltaEnvioUrgente(IRepositorioEnvio repoEnvio,
            IRepositorioUsuario repoUsuario)
        {
            RepoEnvio = repoEnvio;
            RepoUsuario = repoUsuario;
        }

        public int Ejecutar(AltaEnvioUrgenteDTO envioDTO)
        {
            if (envioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }

            Usuario usu = RepoUsuario.GetByEmailUsuario(envioDTO.Email);
            Envio envio = EnvioMapper.EnvioFromEnvioUrgenteDTO(envioDTO, usu);

            RepoEnvio.Alta(envio);
            return envio.Id;
        }
    }
}
