using Compartido.DTOs.AuditoriaDTOs;
using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Mappers
{
    public class AuditoriaMapper
    {

        public static Auditoria AuditoriaFromAuditoriaDTO(AuditoriaDTO auditoriaDTO)
        {
            if (auditoriaDTO == null)
            {
                throw new ArgumentException("Datos incorrectos");
            }
            return new Auditoria(auditoriaDTO.Accion, auditoriaDTO.Fecha, auditoriaDTO.IdEmpleado);
        }


    }
}
