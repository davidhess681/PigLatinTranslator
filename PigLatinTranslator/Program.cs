using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatinTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            do { TranslateUserPhrase(); }
            while (Continue());
        }

        static void TranslateUserPhrase()
        {
            Console.Write("Welcome to the Pig Latin Translator! \nEnter a line to be translated: ");

            string input = Console.ReadLine();

            string[] parsedInput = input.Split(' ');

            for (int i = 0; i < parsedInput.Length; i++)
            {
                Console.Write(PigLatin.Translate(parsedInput[i]) + " ");
            }
            Console.WriteLine("\n");
        }

        static bool Continue()
        {
            Console.Write("Translate another line? (y/n): ");
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        Console.WriteLine("\n");
                        return true;
                    case ConsoleKey.N:
                        return false;
                    default:
                        Console.Write("\nInvalid, try y/n: ");
                        break;
                }
            }
        }
    }
}
