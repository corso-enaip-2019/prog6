using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzoDiCarte
{
    class Program
    {
        static void Main(string[] args)
        {
            Mazzo M = new Mazzo();

            List<Carta> cartePescate = M.Pesca(5);

            foreach (Carta c in cartePescate)
            {
                Console.WriteLine($"{c.Seme} {c.Numero}");
            }

            Console.ReadLine();
        }
    }
}
