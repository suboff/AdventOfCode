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
            }

            Console.WriteLine("Required paper: " + totalRequiredPaper);
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

            minArea = length * width;

            sideArea = width * height;
            if (sideArea < minArea)
            {
                minArea = sideArea;
            }

            sideArea = height * length;
            if (sideArea < minArea)
            {
                minArea = sideArea;
            }

            return minArea;
        }
    }
}
