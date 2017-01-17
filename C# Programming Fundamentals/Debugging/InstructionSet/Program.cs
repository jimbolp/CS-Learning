using System;
using System.Numerics;

class InstructionSet_broken
{
    static void Main()
    {
        string opCode = Console.ReadLine().ToLower();
        long result = 0;

        while (opCode != "end")
        {
            string[] codeArgs = opCode.Split(' ');
            
            switch (codeArgs[0])
            {
                case "inc":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        result = (long)operandOne + 1;
                        Console.WriteLine(result);
                        break;
                    }
                case "dec":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        result = (long)operandOne - 1;
                        Console.WriteLine(result);
                        break;
                    }
                case "add":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        int operandTwo = int.Parse(codeArgs[2]);
                        result = (long)operandOne + (long)operandTwo;
                        Console.WriteLine(result);
                        break;
                    }
                case "mla":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        int operandTwo = int.Parse(codeArgs[2]);
                        result = (long)operandOne * (long)operandTwo;
                        Console.WriteLine(result);
                        break;
                    }
                case "end":
                    break;
                default:
                    break;
            }            
            
            opCode = Console.ReadLine().ToLower();
        }
    }
}