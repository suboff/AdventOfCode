using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int totalRequiredPaper = 0;
            int totalRequiredRibbon = 0;

            using (TextReader reader = new StreamReader(@"Input.txt"))
            {
                input = reader.ReadToEnd();
            }

            string[] sizes = input.Split('\n');

            foreach (string size in sizes)
            {
                string[] dimensions = size.Split('x');
                int length = Int32.Parse(dimensions[0]);
                int width = Int32.Parse(dimensions[1]);
                int height = Int32.Parse(dimensions[2]);
                totalRequiredPaper += GetRequiredWrappingPaper(length, width, height);
                totalRequiredRibbon += GetRequiredRibbon(length, width, height);
            }

            Console.WriteLine("Required paper: " + totalRequiredPaper);
            Console.WriteLine("Required ribbon: " + totalRequiredRibbon);
            Console.ReadKey();

        }

        static int GetRequiredWrappingPaper(int length, int width, int height)
        {
            return GetSurfaceArea(length, width, height) + GetSlack(length, width, height);
        }

        static int GetSurfaceArea(int length, int width, int height)
        {
            return (2 * length * width) + (2 * width * height) + (2 * height * length);
        }

        static int GetSlack(int length, int width, int height)
        {
            int minArea;
            int sideArea = 0;

            minArea = CalculateArea(length, width);

            sideArea = CalculateArea(width, height);
            if (sideArea < minArea)
            {
                minArea = sideArea;
            }

            sideArea = CalculateArea(height, length);
            if (sideArea < minArea)
            {
                minArea = sideArea;
            }

            return minArea;
        }

        static int GetRequiredRibbon(int length, int width, int height)
        {
          return GetSmallestPerimeter(length, width, height) + GetBow(length, width, height);
        }

        static int GetSmallestPerimeter(int length, int width, int height)
        {
          int minPerimeter;
          int sidePerimeter = 0;

          minPerimeter = CalculatePerimeter(length, width);

          sidePerimeter = CalculatePerimeter(width, height);
          if (sidePerimeter < minPerimeter)
          {
            minPerimeter = sidePerimeter;
          }

          sidePerimeter =CalculatePerimeter(height, length);
          if (sidePerimeter < minPerimeter)
          {
            minPerimeter = sidePerimeter;
          }

          return minPerimeter;
        }

        static int GetBow(int length, int width, int height)
        {
          return length * width * height;
        }

        private static int CalculateArea(int x, int y)
        {
          return x * y;
        }

        static int CalculatePerimeter(int x, int y)
        {
          return (2 * x) + (2 * y);
        }
    }
}
