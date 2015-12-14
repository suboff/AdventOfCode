using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
  class Program
  {
    static void Main(string[] args)
    {
      string input = "iwrupvqb";
      long value = 1;
      string hash = "";
      bool found = false;

      using (MD5 md5Hash = MD5.Create())
      {
        do
        {
          hash = GetMD5Hash(md5Hash, input + value.ToString());
          if (hash.Substring(0, 6) == "000000")
          {
            found = true;
          }
          else
          {
            value++;
          }
        } while (!found);
      }

      Console.WriteLine("Hash: " + hash);
      Console.WriteLine("Value: " + value);
      Console.ReadKey();
    }

    static string GetMD5Hash(MD5 md5Hash, string input)
    {
      byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

      StringBuilder builder = new StringBuilder();

      for (int i = 0; i < data.Length; i++)
      {
        builder.Append(data[i].ToString("x2"));
      }

      return builder.ToString();
    }
  }
}
