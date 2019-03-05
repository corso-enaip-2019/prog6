using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioPitagora
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Inserisci il numero dei lati totali:");
            // string inputLati = Console.ReadLine();
            //int righeLati = Convert.ToInt32(inputLati);

            int[] lati = new int[3];

            for (int lato = 0; lato < lati.Length; lato++)
            {
                lati[lato] = AskAndCheckNumber("Inserisci lato " + (lato + 1));
            }

            //bool sumOk = (a < b + c && b < a + c && c < a + b);
            //bool diffOk = (a < Math.Abs(b - c) && b < Math.Abs(a - c) && c < Math.Abs(a - b));
            //if (sumOk && diffOk)
            //{
            //    Console.WriteLine("è un triangolo!");
            //}
            //else
            //{
            //    Console.WriteLine("Non è un triangolo!");
            //}
            //Console.ReadLine();

            if (IsTriangle(lati[0], lati[1], lati[2]))
            {
                Console.WriteLine("è un triangolo");
            }
            else
            {
                Console.WriteLine("Non è un triangolo");

               
                do
                {
                    int m = Math.Max(lati[2], Math.Max(lati[0], lati[1]));

                    int index = Array.IndexOf(lati, m);

                    lati[index] = lati[index]-1;
                 
                } while (!IsTriangle(lati[0], lati[1], lati[2]));

                Console.WriteLine($"Questi valori invece costituiscono un triangolo {lati[0]},{lati[1]},{lati[2]}");
            }
            Console.ReadLine();

        }

        /// <summary>
        /// Mostra all'utente un messaggio e prova a convertire l'input in un intero
        /// </summary>
        /// <param name="message"></param>
        /// <returns>l'intero convertito a partide dalla stringa in input</returns>
        static int AskAndCheckNumber(string message)
        {
            // System.Diagnostics.Debug.WriteLine(string.Concat("Message: ", message));
            int convertedValue;
            Console.WriteLine(message);
            string input = Console.ReadLine();
            bool conversionOk = int.TryParse(input, out convertedValue);
            if (!conversionOk)
                Console.WriteLine("L'imput non è valido");
            if (convertedValue <= 0)
                Console.WriteLine("Il valore deve essere positivo");

            //System.Diagnostics.Debug.WriteLine(string.Format("{0}: {1}", message, input));
            System.Diagnostics.Debug.WriteLine($"{message} : {input}");

            return convertedValue;
        }
        /// <summary>
        /// Verifica se è un triangolo
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        static bool IsTriangle(int a, int b, int c)
        {
            bool sumOk = (a < b + c && b < a + c && c < a + b);
            bool diffOk = (a > Math.Abs(b - c) && b > Math.Abs(a - c) && c > Math.Abs(a - b));

            return sumOk && diffOk;
        }
    }
}
