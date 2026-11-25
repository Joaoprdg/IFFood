using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFFood.Classes.BD.Interfaces
{
    internal interface IBD<T>
    {
        List<T> ListarTodos();
        void Atualizar(T item);
    }
}
