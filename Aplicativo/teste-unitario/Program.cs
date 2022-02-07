using financas_core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste_unitario
{
    public class Program
    {
        public static void Main(string[] args)
        {
            foreach(Fonte fonte in Fonte.listaFontesSemFiltro())
                Console.WriteLine(fonte.ToString());
        }
    }
}
