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

        public bool EsConexo() // verifica si el grafo está conectado
        {
            if (ady.Count == 0) return true; //si no hay nodos, se considera conexo

            var visitados = new HashSet<string>(); // crea un conjunto para marcar nodos visitados
            string inicio = new List<string>(ady.Keys)[0]; //toma un nodo arbitrario para comenzar

            DFS(inicio, visitados); //llama a DFS para marcar todos los nodos alcanzables desde inicio

            return visitados.Count == ady.Count; //compara cantidad de visitados con cantidad total de nodos; si son iguales, el grafo es conexo
        }

        private void DFS(string nodo, HashSet<string> visitados)
        {
            visitados.Add(nodo);

            foreach (var (dest, _) in ady[nodo])
            {
                if (!visitados.Contains(dest))
                    DFS(dest, visitados);
            }
        }

        //Dijkstra para ruta más corta
        public List<string> RutaMasCorta(string inicio, string fin)
        {
            var dist = new Dictionary<string, int>();
            var previo = new Dictionary<string, string>();
            var pq = new SortedSet<(int dist, string nodo)>();

            foreach (var n in ady.Keys)
                dist[n] = int.MaxValue;

            dist[inicio] = 0;
            pq.Add((0, inicio));

            while (pq.Count > 0)
            {
                var (d, actual) = pq.Min;
                pq.Remove(pq.Min);

                if (actual == fin)
                    break;

                foreach (var (vecino, peso) in ady[actual])
                {
                    int nuevaDist = d + peso;

                    if (nuevaDist < dist[vecino])
                    {
                        pq.RemoveWhere(x => x.nodo == vecino);

                        dist[vecino] = nuevaDist;
                        previo[vecino] = actual;

                        pq.Add((nuevaDist, vecino));
                    }
                }

            }
            var ruta = new List<string>();
            string temp = fin;

            while (temp != inicio)
            {
                ruta.Add(temp);
                if (!previo.ContainsKey(temp)) return new List<string>();
                temp = previo[temp];
            }
            ruta.Add(inicio);
            ruta.Reverse();

            return ruta;
        }
    }

    

}
