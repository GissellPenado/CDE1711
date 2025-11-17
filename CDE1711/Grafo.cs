using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDE1711
{
    public class Grafo
    {
        private Dictionary<string, List<(string destino, int peso)>> ady;

        public Grafo()
        {
            ady = new Dictionary<string, List<(string, int)>>();
        }

        public void AgregarNodo(string nombre)
        {
            if (!ady.ContainsKey(nombre))
                ady[nombre] = new List<(string, int)>();
        }

        public void AgregarArista(string a, string b,int peso)
        {
            AgregarNodo(a);
            AgregarNodo(b);

            ady[a].Add((b, peso));
            ady[b].Add((a, peso));

        }

        public void MostrarConexiones()
        {
            foreach (var nodo in ady)
            {
                Console.WriteLine($"{nodo.Key}:");
                foreach (var (dest, peso) in nodo.Value)
                    Console.WriteLine($"  -> {dest} (peso: {peso})");
            }
        }

    }
}
