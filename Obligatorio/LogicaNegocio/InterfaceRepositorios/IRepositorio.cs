using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfaceRepositorios
{
    public interface IRepositorio<T>
    {
        void Alta(T item);
        IEnumerable<T> GetAll();
        T GetPorId(int id);
        void Baja(int id);
        void Editar(T item);
    }
}
