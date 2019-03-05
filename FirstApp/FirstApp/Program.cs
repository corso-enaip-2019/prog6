using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            short s;
            uint ui;
            long l;
            float f;
            double d;
            decimal de;
            string st;
            char c;
            bool b;
            byte bt;

            i = 1;
            i = i + 1;

            //i = i++; incremento del valore di i
            //i = ++i; 
            //i += 1;

            if (i > 1 && i < 10 && i != 5) //operazione di confronto con and
            { }
            else if (i > 2 || i == 5) // operazione di confronto con or
            { }
            else
            { }

            string str = "ciao";
            str = string.Concat(str, " mario");


            Console.WriteLine(str);

            Console.ReadLine();

        }
    }
}
