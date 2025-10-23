using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfaceRepositorios;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioEnvioEF : IRepositorioEnvio
    {
        private ObligatorioContext Contexto { get; set; }
        public RepositorioEnvioEF(ObligatorioContext contexto)
        {
            Contexto = contexto;
        }

        public void Alta(Envio item)
        {
            if (item != null)
            {
                Contexto.Envios.Add(item);
                Contexto.SaveChanges();
            }
        }

        public void Baja(int id)
        {
            Envio envioBuscado = GetPorId(id);
            if (envioBuscado != null)
            {
                envioBuscado.Estado = Estado.FINALIZADO;
                envioBuscado.CalcularTiempoEntrega();

                Contexto.Envios.Update(envioBuscado);
                Contexto.SaveChanges();
            }
            else
            {
                throw new EnvioException("El envio no existe");
            }
        }

        public void Editar(Envio item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Envio> GetAll()
        {
            return Contexto.Envios.Include(envio => envio.Cliente)
                .Include(envio => envio.Empleado).Include(envio=>envio.Comentario);
        }

        public Envio GetPorId(int id)
        {
            return Contexto.Envios.Where(t => t.Id == id).Include(envio => envio.Comentario).SingleOrDefault();
        }

        public void AltaComentario(int idEnvio, Comentario comentario)
        {
            if (idEnvio != null && comentario != null)
            {
                Envio envioBuscado = GetPorId(idEnvio);
                envioBuscado.Comentario.Add(comentario);
                Contexto.Envios.Update(envioBuscado);
                Contexto.SaveChanges();
            }
            else
            {
                throw new EnvioException("Envio u comentario no existe");
            }
        }

        public Envio GetEnvioPorNumeroTracking(string numeroTracking)
        {
            return Contexto.Envios.Where(t => t.NumeroTracking == numeroTracking).Include(envio => envio.Comentario).SingleOrDefault();
        }

    }
}
