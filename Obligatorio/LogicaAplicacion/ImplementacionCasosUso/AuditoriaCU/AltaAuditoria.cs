using Compartido.DTOs.AuditoriaDTOs;
using LogicaAplicacion.InterfaceCasosUso.AuditoriaCU;
using Compartido.Mappers;
using LogicaNegocio.InterfaceRepositorios;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicaAplicacion.ImplementacionCasosUso.AuditoriaCU
{
    public class AltaAuditoria : IAltaAuditoria
    { 
        private IRepositorioAuditoria RepoAuditoria { get; set; }
        public AltaAuditoria(IRepositorioAuditoria repoAuditoria)
        {
            RepoAuditoria = repoAuditoria;
        }

        public void Ejecutar(AuditoriaDTO auditoriaDTO)
        {
            if (auditoriaDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }

            Auditoria auditoria = AuditoriaMapper.AuditoriaFromAuditoriaDTO(auditoriaDTO);
            RepoAuditoria.Alta(auditoria);
        }



    }
}
