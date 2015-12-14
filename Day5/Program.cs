using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
  class Program
  {
    static void Main(string[] args)
    {
      string input;
      int niceStrings = 0;

      using (StreamReader reader = new StreamReader(@"Input.txt"))
      {
        while ((input = reader.ReadLine()) != null)
        {
          if (IsNiceString2(input))
          {
            niceStrings++;
          }
        }
      }

      Console.WriteLine("Number of nice strings: " + niceStrings);
      Console.ReadKey();
    }

    static bool IsNiceString2(string input)
    {
      return ContainsLetterPair(input) && ContainsThreeCharacterPalindrome(input);
    }

    static bool ContainsLetterPair(string input)
    {
      if (input.Length < 4)
      {
        return false;
      }

      for (int i = 0; i < input.Length - 3; i++)
      {
        if(input.Substring(i + 2).Contains(input.Substring(i, 2))) 
        {
          return true;
        }
      }

      return false;
    }

    static bool ContainsThreeCharacterPalindrome(string input)
    {
      if (input.Length < 3)
      {
        return false;
      }

      for (int i = 0; i < input.Length - 2; i++)
      {
        if (input[i] == input[i + 2])
        {
          return true;
        }
      }

      return false;
    }

    static bool IsNiceString(string input)
    {
      return ContainsXVowels(input, 3) && ContainsDoubleLetter(input) && !ContainsBadSubstring(input);
    }

    static bool ContainsXVowels(string input, int requestedNumberOfVowels)
    {
      List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
      int numberOfVowels = 0;

      foreach (char letter in input)
      {
        if (vowels.Contains(letter))
        {
          numberOfVowels++;
          if (numberOfVowels >= requestedNumberOfVowels)
          {
            return true;
          }
        }
      }

      return false;
    }

    static bool ContainsDoubleLetter(string input)
    {
      if (input.Length < 2)
      {
        return false;
      }

      for (int i = 0, j = 1; j < input.Length; i++, j++)
      {
        if (input[i] == input[j])
        {
          return true;
        }
      }

      return false;
    }

    static bool ContainsBadSubstring(string input)
    {
      List<string> badSubstrings = new List<string>() { "ab", "cd", "pq", "xy" };

      foreach (string badSubstring in badSubstrings)
      {
        if (input.Contains(badSubstring))
        {
          return true;
        }
      }

      return false;
    }
  }
}
