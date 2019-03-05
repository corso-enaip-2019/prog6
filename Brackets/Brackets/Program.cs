using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brackets
{

    class Program
    {
        static void Main(string[] args)
        {
            bool ok = CheckBrackets(@"
                namespace Brackets
                {
                    class Program
                    {
                        static void Main(string[] args)
                        {
                            bool ok = CheckBrackets("")
                            Console.ReadLine();
                        }
                        static bool CheckBrackets(string text)
                        {
                        }
                    }
                }");

            string strOk = ok ? "OK" : "KO";
            Console.WriteLine($"Text is { ok }");

            Console.ReadLine();
        }

        /// <summary>
        /// Verifica se il testo passato contiene un numero coerente di parentesi
        /// di apertura e chiusura "(", "[", "{"
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static bool CheckBrackets(string text)
        {
            Stack<char> checkParentesi = new Stack<char>();
            
            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];
                if (currentChar == '(' || currentChar =='[' || currentChar == '{')
                {
                    checkParentesi.Push(currentChar);
                }
                else if (currentChar == ')' || currentChar == ']' || currentChar == '}')
                {
                    if (checkParentesi.Count == 0)
                    {
                        return false;
                    }
                    if (checkParentesi.Peek() == '(' && currentChar == ')')
                    {
                        checkParentesi.Pop();
                    }
                    else if (checkParentesi.Peek() == '[' && currentChar == ']')
                    {
                        checkParentesi.Pop();
                    }
                    else if (checkParentesi.Peek() == '{' && currentChar == '}')
                    {
                        checkParentesi.Pop();
                    }
                    else return false;
                    
                }
                    
            }
            return checkParentesi.Count == 0;
        }
    }
}
