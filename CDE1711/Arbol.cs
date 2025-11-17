using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDE1711
{
    public class Arbol
    {
        public Nodo Raiz { get; set; }
        public Arbol(string raiz)
        {
            Raiz = new Nodo(raiz);
        }

        public void Insertar(string padre, string hijo)
        {
            Nodo nodoPadre = Buscar(Raiz, padre);
            if (nodoPadre != null)
                nodoPadre.Hijos.Add(new Nodo(hijo));
        }

        public Nodo Buscar(Nodo actual, string nombre)
        {
            if (actual.Nombre == nombre)
                return actual;

            foreach (var h in actual.Hijos)
            {
                var encontrado = Buscar(h, nombre);
                if (encontrado != null)
                    return encontrado;
            }
            return null;
        }
        public void Recorrer (Nodo nodo, string prefijo = "")
        {
            Console.WriteLine(prefijo + nodo.Nombre);

            foreach (var hijo in nodo.Hijos)
                Recorrer(hijo, prefijo + "  ");
        }

        public int Contar (Nodo nodo)
        {
            int total = 1;
            foreach (var hijo in nodo.Hijos)
                total += Contar(hijo);
            return total;
        }

        public int Nivel(string nombre)
        {
            return Nivel(Raiz, nombre, 0);
        }

        private int Nivel (Nodo actual, string nombre, int nivel)
        {
            if (actual.Nombre == nombre)
                return nivel;

            foreach (var hijo in actual.Hijos)
            {
                int n = Nivel(hijo, nombre, nivel + 1);
                if (n != -1)
                    return n;
            }
            return -1;
        }
    }
}
