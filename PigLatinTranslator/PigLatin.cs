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
            string pig = english.ToLower();

            // ignore if contains nums and symbols
            if (!IsFormatted(pig))
            {
                return pig;
            }

            char punc = english[english.Length - 1];
            bool endsWPunc = false;
            if (punctuation.Contains(punc))
            {
                endsWPunc = true;
            }

            // translate based on starting character
            if (vowels.Contains(pig[0])) { pig = VowelRule(pig); }
            else { pig = ConsonantRule(pig); }
            
            if (endsWPunc) { return pig + punc; }

            return pig;
        }

        static bool IsFormatted(string word)
        {
            if (Regex.IsMatch(word, @"^[a-zA-Z\'\.,!?]+$"))
            {
                return true;
            }
            return false;
        }

        static string VowelRule(string word)
        {
            return word + "way";
        }

        static string ConsonantRule(string word)
        {
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
