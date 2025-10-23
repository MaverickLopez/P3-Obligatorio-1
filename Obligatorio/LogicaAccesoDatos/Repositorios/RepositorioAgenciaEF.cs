using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfaceRepositorios;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioAgenciaEF : IRepositorioAgencia
    {
        private ObligatorioContext Contexto { get; set; }
        public RepositorioAgenciaEF(ObligatorioContext contexto)
        {
            Contexto = contexto;
        }

        public void Alta(Agencia item)
        {
            Agencia agenciaBuscada = GetByLatitudLongitud(item.Latitud, item.Longitud);
            if (agenciaBuscada == null)
            {
                Contexto.Agencias.Add(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new AgenciaExcepction("Agencia ya existente");
            }
        }

        public void Baja(int id)
        {
            throw new NotImplementedException();
        }

        public void Editar(Agencia item)
        {
            Agencia agenciaBuscada = GetByLatitudLongitudEditar(item.Id, item.Latitud, item.Longitud);

            if (agenciaBuscada == null)
            {
                Contexto.Agencias.Update(item);
                Contexto.SaveChanges();
            }
            else
            {
                throw new AgenciaExcepction("Agencia ya existente en esa ubicacion");
            }
        }

        public IEnumerable<Agencia> GetAll()
        {
            return Contexto.Agencias;
        }

        public Agencia GetPorId(int id)
        {
            return Contexto.Agencias.Find(id);
        }

        private Agencia GetByLatitudLongitud(double latitud, double longitud)
        {
            return Contexto.Agencias.Where(a => a.Latitud == latitud && a.Longitud == longitud).SingleOrDefault();
        }

        private Agencia GetByLatitudLongitudEditar(int id, double latitud, double longitud)
        {
            return Contexto.Agencias.Where(a =>a.Id != id && a.Latitud == latitud && a.Longitud == longitud).SingleOrDefault();
        }
    }
}
