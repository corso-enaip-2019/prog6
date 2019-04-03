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
                {(
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
            List<char> openingBrackets = new List<char>() { '(', '[', '{' };
            //Spostato in inizializzazione
            //openingBrackets.Add('(');
            //openingBrackets.Add('[');
            //openingBrackets.Add('{');

            List<char> closedBrackets = new List<char>() { ')', ']', '}' };
            //Spostato in inizializzazione
            //closedBrackets.Add(')');
            //closedBrackets.Add(']');
            //closedBrackets.Add('}');

            Stack<char> checkParentesi = new Stack<char>();
            
            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];

                if (openingBrackets.Contains(currentChar))
                {
                    checkParentesi.Push(currentChar);
                }

                //if (currentChar == '(' || currentChar == '[' || currentChar == '{')
                //{
                //    checkParentesi.Push(currentChar);
                //}
                else if (closedBrackets.Contains(currentChar))
                //else if (currentChar == ')' || currentChar == ']' || currentChar == '}')
                {
                    //spostato in metodo separato
                    //char correspondingOpeningBrackets = ' ';
                    //if (currentChar == ')')
                    //    correspondingOpeningBrackets = '(';
                    //else if (currentChar == ']')
                    //    correspondingOpeningBrackets = '[';
                    //else if (currentChar == '}')
                    //    correspondingOpeningBrackets = '{';

                    if (checkParentesi.Count == 0)
                        return false;

                    if (checkParentesi.Peek() == CorrespondingOpeningBracket(currentChar))
                        checkParentesi.Pop();
                    else
                    {
                        return false;
                    }

                    char CorrespondingOpeningBracket(char closedBracket)
                    {
                        int closingIndex = closedBrackets.IndexOf(closedBracket);
                        return openingBrackets[closingIndex];

                        char correspondingOpeningBracket = ' ';
                        if (closedBracket == ')')
                            correspondingOpeningBracket = '(';
                        else if (closedBracket == ']')
                            correspondingOpeningBracket = '[';
                        else if (closedBracket == '}')
                            correspondingOpeningBracket = '{';

                        return correspondingOpeningBracket;
                    }

                    //if (checkParentesi.Count == 0)
                    //{
                    //    return false;
                    //}
                    //if (checkParentesi.Peek() == '(' && currentChar == ')')
                    //{
                    //    checkParentesi.Pop();
                    //}
                    //else if (checkParentesi.Peek() == '[' && currentChar == ']')
                    //{
                    //    checkParentesi.Pop();
                    //}
                    //else if (checkParentesi.Peek() == '{' && currentChar == '}')
                    //{
                    //    checkParentesi.Pop();
                    //}
                    //else return false;

                }

                char CorrespondingOpeningBracket(char closingBracket)
                {
                    int closingIndex = closedBrackets.IndexOf(closingBracket);
                    return openingBrackets[closingIndex];

                    char correspondingOpeningBracket = ' ';
                    if (closingBracket == ')')
                        correspondingOpeningBracket = '(';
                    else if (closingBracket == ']')
                        correspondingOpeningBracket = '[';
                    else if (closingBracket == '}')
                        correspondingOpeningBracket = '{';

                    return correspondingOpeningBracket;
                }
            }
            return checkParentesi.Count == 0;


        }

        
    }
}
