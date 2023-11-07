using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeUniversidad.Otros;

namespace SistemaDeUniversidad.Otros
{
    public class Node<T>
    {
        public T valor;
        public Node<T>? siguiente;

        public Node(T valor)
        {
            this.valor = valor;
            this.siguiente = null;
        }
    }
}
