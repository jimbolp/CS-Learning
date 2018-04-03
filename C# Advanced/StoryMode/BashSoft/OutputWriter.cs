
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

public static class OutputWriter
{
    public static void WriteMessage(string message)
    {
        Console.Write(message);
    }

    public static void WriteMessageOnNewLine(string message)
    {
        Console.WriteLine(message);
    }

    public static void WriteEmptyLine()
    {
        Console.WriteLine();
    }

    public static void DisplayException(string message)
    {
        ConsoleColor currentColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = currentColor;
    }

    public static void TraverseFolder(string path)
    {
        WriteEmptyLine();
        int initialIdentation = path.Split('\\').Length;
        Queue<string> subFolders = new Queue<string>();
        subFolders.Enqueue(path);
        while (subFolders.Count != 0)
        {
            string currentPath = subFolders.Dequeue();
            int identation = currentPath.Split('\\').Length - initialIdentation;
            try
            {
                foreach (string directoryPath in Directory.GetDirectories(currentPath))
                {
                    subFolders.Enqueue(directoryPath);
                }
                WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', identation), currentPath));
            }
            catch (UnauthorizedAccessException e)
            {
                DisplayException("Access to the path " + string.Format(currentPath) + " is denied.");
            }
            catch (Exception e)
            {
                DisplayException(e.ToString());
            }
        }
    }
}


