using System;
using System.Collections.Generic;

namespace Lozung
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> alphabet = new List<char>
            {
                'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'
            };

            string lozungCode = Console.ReadLine();
            lozungCode = DeleteExtraLetters(lozungCode);
            Console.WriteLine(lozungCode + " -- lozungCode");

            List<char> newAlphabet = new List<char>
            {
                'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'
            };

            newAlphabet.InsertRange(0, lozungCode);
            newAlphabet = DeleteExtraLetters(newAlphabet);

            PrintList(alphabet, " -- alphabet");
            PrintList(newAlphabet, " -- NEWalphabet");

            string word = Console.ReadLine();
            word = Encryption(newAlphabet, alphabet, word);
            Console.WriteLine(word + " -- Encryption");
        }
        static string DeleteExtraLetters(string word)
        {
            for (int i = 0; i < word.Length; i++)
                for (int j = 0; j < word.Length; j++)
                {
                    if (word[i] == word[j] && i != j)
                    {
                        word = word.Substring(0, j) + word.Substring(j + 1);
                    }
                }
            return word;
        }
        static List<char> DeleteExtraLetters(List<char> word)
        {
            for (int i = 0; i < word.Count; i++)
                for (int j = 0; j < word.Count; j++)
                {
                    if (word[i] == word[j] && i != j)
                    {
                        word.RemoveAt(j);
                    }
                }
            return word;
        }
        static string Encryption(List<char> newAlphabet, List<char> alphabet, string word)
        {
            string cryptWord = "";
            for (int i = 0; i < word.Length; i++)
                for (int j = 0; j < alphabet.Count; j++)
                    if (alphabet[j] == word[i])
                    {
                        cryptWord += newAlphabet[j];
                    }
            return cryptWord;
        }

        static void PrintList(List<char> print, string info)
        {
            for (int i = 0; i < print.Count; i++)
                Console.Write(print[i]);
            Console.Write(info + "\n");
        }
    }
}