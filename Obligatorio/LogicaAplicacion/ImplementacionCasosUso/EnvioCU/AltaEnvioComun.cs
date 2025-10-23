using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compartido.DTOs.EnvioDTOs;
using Compartido.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.InterfaceCasosUso.EnvioCU;
using LogicaNegocio.InterfaceRepositorios;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class AltaEnvioComun : IAltaEnvioComun
    {
        private IRepositorioEnvio RepoEnvio { get; set; }
        private IRepositorioUsuario RepoUsuario { get; set; }
        private IRepositorioAgencia RepoAgencia { get; set; }

        public AltaEnvioComun(IRepositorioEnvio repoEnvio,
            IRepositorioUsuario repoUsuario,
            IRepositorioAgencia repoAgencia)
        {
            RepoEnvio = repoEnvio;
            RepoUsuario = repoUsuario;
            RepoAgencia = repoAgencia;
        }

        public int Ejecutar(AltaEnvioComunDTO envioDTO)
        {
            if (envioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }

            Usuario usu = RepoUsuario.GetByEmailUsuario(envioDTO.Email);
            Agencia age = RepoAgencia.GetPorId(envioDTO.AgenciaId);
            Envio envio = EnvioMapper.EnvioFromEnvioComunDTO(envioDTO, usu, age);

            RepoEnvio.Alta(envio);
            return envio.Id;
        }
    }
}
