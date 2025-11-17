using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDE1711
{
    public class Nodo
    {
        public string Nombre { get; set; }
        public List<Nodo> Hijos { get; set; }

        public Nodo (string nomnbre)
        {
            Nombre = Nombre;
            Hijos = new List<Nodo>();
        }
    }
}
