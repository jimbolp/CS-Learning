using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class WorkingWithDirectories
{
    static void Main(string[] args)
    {
        try
        {
            Directory.Delete("Folder");
        }
        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
            if(File.Exists("log.txt"))
                File.AppendAllText("log.txt", $"{Environment.NewLine}{new string('-', 40)}{Environment.NewLine}{DateTime.Now}{Environment.NewLine}{e.Message}{Environment.NewLine}{e.StackTrace}");
            else
            {
                File.WriteAllText("log.txt", $"{new string('-', 40)}{Environment.NewLine}{DateTime.Now}{Environment.NewLine}{e.Message}{Environment.NewLine}{e.StackTrace}");
            }
            
        }
        string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
        try
        {
            Test();
        }
        catch (MyException e)
        {
            
            Console.WriteLine(e.MyMessage);
            if (File.Exists("log.txt"))
                File.AppendAllText("log.txt", $"{Environment.NewLine}{new string('-', 40)}{Environment.NewLine}{DateTime.Now}{Environment.NewLine}{e.MyMessage}{Environment.NewLine}{e.StackTrace}");
            else
            {
                File.WriteAllText("log.txt", $"{new string('-', 40)}{Environment.NewLine}{DateTime.Now}{Environment.NewLine}{e.MyMessage}{Environment.NewLine}{e.StackTrace}");
            }
        }
        Console.WriteLine(string.Join("\n", files));
    }

    public static void Test()
    {
        throw new MyException("Just a Test Exception!");
    }
}

sealed class MyException : Exception
{
    public string MyMessage{get;}
    public MyException(string message)
    {
       MyMessage = message;
    }

    public MyException()
    {
        MyMessage = Message;
    }
}

