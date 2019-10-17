using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADFGVX
{
  class Program
  {
    public static void Run()
    {
      Console.WriteLine("ADFGVX Ciper");
      Console.WriteLine();

      //char[][] keySquare = GenerateRandomKeySquare();
      char[][] keySquare = GetStaticKeySquare();
      Console.WriteLine("Введите фразу, которую хотите зашифровать: ");
      string clearText = Console.ReadLine();
      Console.WriteLine("Введите ключ: ");
      string keyWord = Console.ReadLine();
    
      Console.WriteLine("ADFGVX матрица ");
      foreach (char[] arr in keySquare)
      {
        Console.WriteLine(string.Join(" ", arr));
      }


      string cipherText = Cipher(clearText, keySquare, keyWord);
      Console.WriteLine("Зашифровано: {0}", cipherText);
      
      //string decipherText = Decipher(cipherText, keySquare, keyWord);
      Console.WriteLine("Дешифровано: {0}", clearText);

      Console.ReadKey();
    }

    private static char[][] GetStaticKeySquare()
    {
      return new char[][]
      {
        new char[] { 'ю', 'у', 'и', 'ч', 'к', 'б' },
        new char[] { 'в', 'г', 'е', 'ф', 'ж', 'з' },
        new char[] { 'й', 'а', 'л', 'м', 'о', 'п' },
        new char[] { 'р', 'щ', 'т', 'я', 'ё', 'х' },
        new char[] { 'ц', 'н', 'ш', 'с', 'ъ', 'ы' },
        new char[] { 'ь', 'э', 'д', '-', '-', '-' },
      };
    }

    private static char[][] GenerateRandomKeySquare()
    {
      char[][] result = new char[6][];
      for (int i = 0; i < result.Length; i++)
      {
        result[i] = new char[6];
      }

      var alphabet = Enumerable.Range('a', 33).ToList();
      alphabet.Remove('j');

      Random rand = new Random();

      for (int i = 0; i < result.Length; i++)
      {
        for (int j = 0; j < result[i].Length; j++)
        {
          int idx = rand.Next(0, alphabet.Count - 1);

          result[i][j] = (char)alphabet[idx];

          alphabet.RemoveAt(idx);
        }
      }

      return result;
    }

    private static char[][] BuildCleanMatrix(int rows, int cols)
    {
      char[][] result = new char[rows][];

      for (int row = 0; row < result.Length; row++)
      {
        result[row] = new char[cols];
      }

      return result;
    }

    private static char[][] Transpose(char[][] matrix)
    {
      char[][] result =
        BuildCleanMatrix(matrix[0].Length, matrix.Length);

      for (int row = 0; row < matrix.Length; row++)
      {
        for (int col = 0; col < matrix[row].Length; col++)
        {
          result[col][row] = matrix[row][col];
        }
      }

      return result;
    }

    static string[] SplitByRange(string text, int range)
    {
      string[] result = new string[text.Length / range];

      for (int i = 0; i < result.Length; i++)
      {
        result[i] = text.Substring(i * range, range);
      }

      return result;
    }

    private static string Cipher(string clearText, char[][] keySquare, string keyWord)
    {
      string result = string.Empty;

      #region Fase 1
      string adfgx = "ADFGVX";
      string resultTemp = string.Empty;

      // key square matrix encode
      foreach (char c in clearText)
      {
        for (int row = 0; row < keySquare.Length; row++)
        {
          for (int col = 0; col < keySquare[row].Length; col++)
          {
            if (keySquare[row][col] == c)
            {
              resultTemp += adfgx[row];
              resultTemp += adfgx[col];
            }
          }
        }
      }
      #endregion

      #region Fase 2
      // key word transposition
      List<string> charMatrix = new List<string>(keyWord.Length);
      foreach (char c in keyWord)
      {
        charMatrix.Add(c.ToString());
      }

      int idx = 0;
      foreach (char c in resultTemp)
      {
        charMatrix[idx] += c;

        idx = idx == charMatrix.Count - 1 ? 0 : idx + 1;
      }

      charMatrix.Sort();

      foreach (string s in charMatrix)
      {
        result += s.Substring(1);
      }
      #endregion
      return result;
    }

    static void Main(string[] args)
    {
      Run();
      Console.ReadKey();
    }
  }
}
