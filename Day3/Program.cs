using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
  public enum Direction
  {
    North,
    South,
    East,
    West
  }

  class Program
  {
    /// <summary>
    /// X, Y, number of presents
    /// </summary>
    private static Dictionary<Tuple<int, int>, int> _map;

    static void Main(string[] args)
    {
      string input;
      string santasDirections = "";
      string roboSantasDirections = "";
      string userInput;
      int santaX = 0;
      int santaY = 0;
      int roboSantaX = 0;
      int roboSantaY = 0;
      Tuple<int, int> santaLocation = new Tuple<int,int>(santaX, santaY);
      Tuple<int, int> roboSantaLocation = new Tuple<int, int>(roboSantaX, roboSantaY);
      bool roboSantaActive = false;

      Console.Write("Enable Robo-Santa? (y/n): ");
      userInput = Console.ReadLine();
      if (userInput == "y")
      {
        roboSantaActive = true;
      }

      _map = new Dictionary<Tuple<int, int>, int>();
      _map.Add(santaLocation, 1);
      if (roboSantaActive)
      {
        _map[roboSantaLocation]++;
      }

      using (TextReader reader = new StreamReader(@"Input.txt"))
      {
        input = reader.ReadToEnd();
        if (roboSantaActive)
        {
          for (int i = 0; i < input.Length; i++ )
          {
            if (i % 2 == 0)
            {
              santasDirections += input[i];
            }
            else
            {
              roboSantasDirections += input[i];
            }
          }
        }
        else
        {
          santasDirections = input;
        }
      }

      // Move Santa
      foreach (char direction in santasDirections)
      {
        switch (direction)
        {
          case '^':
            santaY++;
            break;
          case 'v':
            santaY--;
            break;
          case '>':
            santaX++;
            break;
          case '<':
            santaX--;
            break;
          default:
            break;
        }

        santaLocation = new Tuple<int,int>(santaX, santaY);
        if (!_map.ContainsKey(santaLocation))
        {
          _map.Add(santaLocation, 1);
        }
        else
        {
          _map[santaLocation]++;
        }
      }

      // Move Robo-Santa
      foreach (char direction in roboSantasDirections)
      {
        switch (direction)
        {
          case '^':
            roboSantaY++;
            break;
          case 'v':
            roboSantaY--;
            break;
          case '>':
            roboSantaX++;
            break;
          case '<':
            roboSantaX--;
            break;
          default:
            break;
        }

        roboSantaLocation = new Tuple<int, int>(roboSantaX, roboSantaY);
        if (!_map.ContainsKey(roboSantaLocation))
        {
          _map.Add(roboSantaLocation, 1);
        }
        else
        {
          _map[roboSantaLocation]++;
        }
      }

      Console.WriteLine("Number of houses visited: " + _map.Count);
      Console.ReadKey();
    }
  }
}
