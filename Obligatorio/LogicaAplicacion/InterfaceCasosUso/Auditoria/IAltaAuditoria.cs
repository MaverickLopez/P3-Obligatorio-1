using Compartido.DTOs.AuditoriaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfaceCasosUso.AuditoriaCU
{
    public interface IAltaAuditoria
    {
        public void Ejecutar(AuditoriaDTO auditoriaDTO);
    }
}
