using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23
{
  class Program
  {
    static List<Command> _commands;
    static int _line;
    static Register _registerA;
    static Register _registerB;

    static void Main(string[] args)
    {
      string input;
      _commands = new List<Command>();
      _line = 0;
      _registerA = new Register();
      //_registerA.Value = 1;
      _registerB = new Register();

      using (StreamReader reader = new StreamReader(@"Input.txt"))
      {
        while ((input = reader.ReadLine()) != null)
        {
          _commands.Add(new Command(input, _registerA, _registerB));
        }
      }

      RunProgram();

      Console.WriteLine("Register A: " + _registerA.Value);
      Console.WriteLine("Register B: " + _registerB.Value);
      Console.ReadKey();
    }

    private static void RunProgram()
    {
      while (_line < _commands.Count)
      {
        RunCommand(_commands[_line]);        
      }
    }

    private static void RunCommand(Command command)
    {
      if (command.Instruction == "hlf")
      {
        command.Register.Value /= 2;
        _line++;
      }
      else if (command.Instruction == "tpl")
      {
        command.Register.Value *= 3;
        _line++;
      }
      else if (command.Instruction == "inc")
      {
        command.Register.Value++;
        _line++;
      }
      else if (command.Instruction == "jmp")
      {
        _line += command.Offset;
      }
      else if (command.Instruction == "jie")
      {
        if (command.Register.Value % 2 == 0)
        {
          _line += command.Offset;
        }
        else
        {
          _line++;
        }
      }
      else if (command.Instruction == "jio")
      {
        if (command.Register.Value == 1)
        {
          _line += command.Offset;
        }
        else
        {
          _line++;
        }
      }
    }
  }

  class Command
  {
    public string Instruction;
    public Register Register;
    public int Offset;

    public Command(string input, Register registerA, Register registerB)
    {
      input = input.Replace(",", "");
      string[] args = input.Split(' ');

      Instruction = args[0];

      switch (Instruction)
      {
        case "hlf":
        case "inc":
        case "tpl":
          Register = (args[1] == "a") ? registerA : registerB;
          break;
        case "jmp":
          Offset = Int32.Parse(args[1]);
          break;
        case "jie":
        case "jio":
          Register = (args[1] == "a") ? registerA : registerB;
          Offset = Int32.Parse(args[2]);
          break;
        default:
          break;
      }
    }
  }

  class Register
  {
    public uint Value;

    public Register()
    {
      Value = 0;
    }
  }
}
