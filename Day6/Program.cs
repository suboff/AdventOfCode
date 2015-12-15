using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
  enum Operation
  {
    On,
    Off,
    Toggle
  };

  class Program
  {
    static void Main(string[] args)
    {
      //bool[,] grid = new bool[1000,1000];
      int[,] grid = new int[1000, 1000];
      string input;
      Operation operation;
      int x1;
      int y1;
      int x2;
      int y2;
      int numberOfLightsOn = 0;
      int totalBrightness = 0;

      for (int i = 0; i < grid.GetLength(0); i++)
      {
        for (int j = 0; j < grid.GetLength(1); j++)
        {
          //grid[i, j] = false;
          grid[i, j] = 0;
        }
      }

      using (StreamReader reader = new StreamReader(@"Input.txt"))
      {
        while ((input = reader.ReadLine()) != null)
        {
          ParseInput(input, out operation, out x1, out y1, out x2, out y2);

          ProcessInput(grid, operation, x1, y1, x2, y2);
        }
      }

      for (int i = 0; i < grid.GetLength(0); i++)
      {
        for (int j = 0; j < grid.GetLength(1); j++)
        {
          //if (grid[i, j])
          //{
          //  numberOfLightsOn++;
          //}
          totalBrightness += grid[i, j];
        }
      }

      Console.WriteLine("Number of lights on: " + numberOfLightsOn);
      Console.WriteLine("Total brightness: " + totalBrightness);
      Console.ReadKey();
    }

    private static void ProcessInput(int[,] grid, Operation operation, int x1, int y1, int x2, int y2)
    {
      for (int i = x1; i <= x2; i++)
      {
        for (int j = y1; j <= y2; j++)
        {
          switch (operation)
          {
            case Operation.On:
              //grid[i, j] = true;
              grid[i, j]++;
              break;
            case Operation.Off:
              //grid[i, j] = false;
              if (grid[i, j] > 0)
              {
                grid[i, j]--;
              }
              break;
            case Operation.Toggle:
              //grid[i, j] = !grid[i, j];
              grid[i, j] += 2;
              break;
            default:
              break;
          }
        }
      }
    }

    private static void ParseInput(string input, out Operation operation, out int x1, out int y1, out int x2, out int y2)
    {
      string[] pieces = input.Split(' ');
      int coordinate1Position = 0;
      int coordinate2Position = 0;

      // Toggle format
      if (pieces.Length == 4)
      {
        operation = Operation.Toggle;
        coordinate1Position = 1;
        coordinate2Position = 3;
      }
      // On/Off format
      else
      {
        if (pieces[1] == "on")
        {
          operation = Operation.On;
        }
        else
        {
          operation = Operation.Off;
        }

        coordinate1Position = 2;
        coordinate2Position = 4;
      }

      ParseCoordinate(pieces[coordinate1Position], out x1, out y1);
      ParseCoordinate(pieces[coordinate2Position], out x2, out y2);
    }

    private static void ParseCoordinate(string coordinate, out int x, out int y)
    {
      string[] pieces = coordinate.Split(',');
      x = Int32.Parse(pieces[0]);
      y = Int32.Parse(pieces[1]);
    }
  }
}
