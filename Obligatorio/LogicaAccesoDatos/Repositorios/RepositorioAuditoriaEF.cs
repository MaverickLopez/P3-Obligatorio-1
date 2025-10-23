using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfaceRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioAuditoriaEF : IRepositorioAuditoria
    {
        private ObligatorioContext Contexto { get; set; }
        public RepositorioAuditoriaEF(ObligatorioContext contexto)
        {
            Contexto = contexto;
        }

        public void Alta(Auditoria item)
        {
            Contexto.Auditorias.Add(item);
            Contexto.SaveChanges();
        }

        public void Baja(int id)
        {
            throw new AuditoriaException("No se puede dar de baja una auditoria");
        }

        public void Editar(Auditoria item)
        {
            throw new AuditoriaException("No se puede editar una auditoria");
        }

        public IEnumerable<Auditoria> GetAll()
        {
            return Contexto.Auditorias;
        }

        public Auditoria GetPorId(int id)
        {
            return Contexto.Auditorias.Find(id);
        }
    }
}
