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
            Console.Write("Welcome to the Pig Latin Translator! \nEnter a line to be translated: ");

            string input = Console.ReadLine();

            string[] parsedInput = input.Split(' ');

            for(int i = 0; i < parsedInput.Length; i++)
            {
                Console.Write(PigLatin.Translate(parsedInput[i]) + " ");
            }

            Console.ReadKey();
        }
    }
}
