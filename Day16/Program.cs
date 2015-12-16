using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
  class Program
  {
    static List<string> keywords = new List<string>() { 
        "children", "cats", "samoyeds", "pomeranians", "akitas", "vizslas", "goldfish", "trees", "cars", "perfumes"
      };
    static List<int> searchValues = new List<int>() {
      3, 7, 2, 3, 0, 0, 5, 3, 2, 1
    };

    static void Main(string[] args)
    {
      AuntSue[] aunts = new AuntSue[500];
      string input;
      int auntNumber = 1;

      using (StreamReader reader = new StreamReader(@"Input.txt"))
      {
        while ((input = reader.ReadLine()) != null)
        {
          AuntSue aunt = new AuntSue(auntNumber);
          aunts[auntNumber - 1] = aunt;
          ParseInput(input, aunt);
          auntNumber++;
        }
      }

      foreach (AuntSue aunt in aunts)
      {
        bool matches = true;
        for (int i = 0; i < keywords.Count && matches; i++)
        {
          string keyword = keywords[i];
          int value;

          if (aunt.Attributes.TryGetValue(keyword, out value))
          {
            if (keyword == "cats" || keyword == "trees")
            {
              if (value <= searchValues[i])
              {
                matches = false;
              }
            }
            else if (keyword == "pomeranians" || keyword == "goldfish")
            {
              if (value >= searchValues[i])
              {
                matches = false;
              }
            }
            else
            {
              if (value != searchValues[i])
              {
                matches = false;
              }
            }
          }
        }

        if (matches)
        {
          Console.WriteLine("Aunt " + aunt.AuntNumber + " is the winner!");
        }
      }

      Console.ReadKey();
    }

    private static void ParseInput(string input, AuntSue auntSue)
    {
      int index = -1;
      int value;
      foreach (string keyword in keywords)
      {
        if ((index = input.IndexOf(keyword)) > -1)
        {
          // The value + the rest of the string
          string substring = input.Substring(input.IndexOf(' ', index) + 1);
          if ((index = substring.IndexOf(',')) > -1)
          {
            value = Int32.Parse(substring.Substring(0, index));
          }
          else
          {
            value = Int32.Parse(substring);
          }

          auntSue.AddValue(keyword, value);
        }
      }
    }
  }

  class AuntSue
  {
    public Dictionary<string, int> Attributes;
    public int AuntNumber;

    public AuntSue(int auntNumber)
    {
      Attributes = new Dictionary<string, int>();
      AuntNumber = auntNumber;
    }

    public void AddValue(string key, int value)
    {
      Attributes.Add(key, value);
    }

    public void PrintAttributes()
    {
      foreach (KeyValuePair<string, int> attribute in Attributes)
      {
        Console.WriteLine(attribute.Key + ": " + attribute.Value);
      }
    }
  }
}
