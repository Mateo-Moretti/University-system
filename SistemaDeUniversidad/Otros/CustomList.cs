using SistemaDeUniversidad.Otros;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeUniversidad.Otros
{
    public class CustomList<T> : IEnumerable<T>
    {
        private Node<T> primero;
        private int cantidadDeElementos = 0;
        private T[] items;
  
        //Agrega un elemento a la lista
        public void Add(T valorAgregado)
        {
            Node<T> nodoNuevo = new Node<T>(valorAgregado); 
            nodoNuevo.siguiente = this.primero;
            this.primero = nodoNuevo;
            cantidadDeElementos++;
        }       

        //Por ahora lo uso solo para chequear que la lista funciona
        public int ElementosTotales()
        {
            int cantidad = 0;
            Node<T>? actual = this.primero;

            while (actual != null)
            {               
                actual = actual.siguiente;
                cantidad++;
            }        
            return cantidad;

            //return cantidadDeElementos;
        }


        //public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value)


        //PELIGRO, MAGIA DE ALTO NIVEL, NO TOCAR A MENOS QUE SEA NECESARIO
        //(Implemente IEnumerable<T> para poder usar foreach con mi lista. El mismo visual studio me dijo que hacer)
        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? actual = primero;

            while (actual != null)
            {
                yield return actual.valor;
                actual = actual.siguiente;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
