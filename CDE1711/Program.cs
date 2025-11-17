using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDE1711
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Árbol
            Arbol jerarquia = new Arbol("Director General");

            jerarquia.Insertar("Director General", "Administración");
            jerarquia.Insertar("Director General", "Tecnologías");
            jerarquia.Insertar("Tecnologías", "Infraestructura");
            jerarquia.Insertar("Tecnologías", "Laboratorio Innovación");

            Console.WriteLine("=== Jerarquía ===");
            jerarquia.Recorrer(jerarquia.Raiz);
            Console.WriteLine($"Total de áreas: {jerarquia.Contar(jerarquia.Raiz)}");


            //Grafo
            Grafo rutas = new Grafo();

            rutas.AgregarArista("Edificio A", "Edificio B", 10);
            rutas.AgregarArista("Edificio B", "Edificio C", 6);
            rutas.AgregarArista("Edificio A", "Edificio C", 15);
            rutas.AgregarArista("Edificio C", "Laboratorio", 5);

            Console.WriteLine("\n=== Conexiones del Parque ===");
            rutas.MostrarConexiones();

            Console.WriteLine("\n¿El grafo es conexo?: " + rutas.EsConexo());

            var ruta = rutas.RutaMasCorta("Edificio A", "Laboratorio");

            Console.WriteLine("\nRuta más corta:");
            Console.WriteLine(string.Join(" -> ", ruta));
        }
    }
}
