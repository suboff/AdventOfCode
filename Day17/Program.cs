using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
  class Program
  {
    private static List<List<int>> _validCombinations = new List<List<int>>();

    static void Main(string[] args)
    {
      string input;
      int volume = 150;
      List<int> availableContainers = new List<int>();
      int minContainers = 999;
      int combinationsUsingMinContainers = 0;

      using (StreamReader reader = new StreamReader(@"Input.txt"))
      {
        while ((input = reader.ReadLine()) != null)
        {
          availableContainers.Add(Int32.Parse(input));
        }
      }

      availableContainers = availableContainers.OrderByDescending(num => num).ToList();

      StartSearch(volume, availableContainers);

      for (int i = 0; i < _validCombinations.Count; i++)
      {
        if (_validCombinations[i].Count < minContainers)
        {
          minContainers = _validCombinations[i].Count;
          combinationsUsingMinContainers = 1;
        }
        else if (_validCombinations[i].Count == minContainers)
        {
          combinationsUsingMinContainers++;
        }
        foreach (int container in _validCombinations[i])
        {
          Console.Write(container + ", ");
        }
        Console.WriteLine();
      }

      Console.WriteLine("Number of combinations: " + _validCombinations.Count);
      Console.WriteLine("Minimum number of containers: " + minContainers);
      Console.WriteLine("Combinations using minimum number of containers: " + combinationsUsingMinContainers);
      Console.ReadKey();
    }

    private static void StartSearch(int volume, List<int> availableContainers)
    {
      List<int> newAvailableContainers = new List<int>(availableContainers);
      List<int> usedContainers = new List<int>();
      FindCombinations(volume, newAvailableContainers, usedContainers);
    }

    private static void FindCombinations(int volume, List<int> availableContainers, List<int> usedContainers)
    {
      if (volume == 0)
      {
        _validCombinations.Add(usedContainers);
        return;
      }
      if (availableContainers.Count == 0)
      {
        return;
      }
      if (volume < 0)
      {
        return;
      }

      List<int> newAvailableContainers = new List<int>(availableContainers);
      
      foreach (int container in availableContainers)
      {
        List<int> newUsedContainers = new List<int>(usedContainers);
        newAvailableContainers.Remove(container);
        newUsedContainers.Add(container);
        FindCombinations(volume - container, newAvailableContainers, newUsedContainers);
      }
    }
  }
}
