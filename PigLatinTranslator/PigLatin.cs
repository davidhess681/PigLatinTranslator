using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PigLatinTranslator
{
    class PigLatin
    {
        readonly static char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
        readonly static char[] punctuation = { '!', '?', '.', ',' };

        public static string Translate(string english)
        {
            string pig = CutPunctuation(english.ToLower(), out string punc);

            // ignore if contains nums and symbols
            if (!IsFormatted(pig))
            {
                return pig;
            }

            // translate based on starting character
            if (vowels.Contains(pig[0])) { pig = VowelRule(pig); }
            else { pig = ConsonantRule(pig); }
            

            return pig + punc;
        }

        static bool IsFormatted(string word)
        {
            if (Regex.IsMatch(word, @"^[a-zA-Z\'\.,!?]+$"))
            {
                return true;
            }
            return false;
        }

        static string CutPunctuation(string word, out string punc)
        {
            // Split ending punctuation from the word. Returns the remaining word and outs the cut punctuation.

            int index = word.Length - 1;
            punc = "";
            while (index >= 0) 
            {
                if (!punctuation.Contains(word[index]))
                {
                    break;
                }
                punc = word[index] + punc;
                index--;
            }

            return word.Substring(0, index + 1);
        }

        static string VowelRule(string word)
        {
            return word + "way";
        }

        static string ConsonantRule(string word)
        {
            if(word.Length == 1)
            {
                return word + "ay";
            }
            
            // rearrange consonants
            int wordLength = word.Length;
            for (int i = 0; i < wordLength; i++)
            {
                // if char is vowel, trim preceeding chars and break
                if (vowels.Contains(word[i]))
                {
                    word = word.Substring(i);
                    break;
                }

                // add char to the end
                word += word[i];

                // if all chars are not vowels, we still have to trim
                if (i == wordLength - 1)
                {
                    word = word.Substring(i);
                }
            }

            // add ay
            return word + "ay";
        }
    }
}
