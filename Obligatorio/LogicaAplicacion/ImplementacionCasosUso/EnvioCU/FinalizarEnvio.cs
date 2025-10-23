using LogicaAplicacion.InterfaceCasosUso.EnvioCU;
using LogicaNegocio.InterfaceRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.EnvioCU
{
    public class FinalizarEnvio : IFinalizarEnvio
    {
        private IRepositorioEnvio RepoEnvio { get; set; }
        public FinalizarEnvio(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }

        public void Ejecutar(int id)
        {
            RepoEnvio.Baja(id);
        }
    }
}
