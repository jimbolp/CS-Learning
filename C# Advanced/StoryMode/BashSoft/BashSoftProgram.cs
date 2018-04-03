
using System;

class BashSoftProgram
{
    public static void Main()
    {
        //OutputWriter.DisplayException("bla bla test");
        //OutputWriter.TraverseFolder(@"E:\Documents\Visual Studio 2015\Projects\C# Advanced\StoryMode");
        string input = Console.ReadLine();
        OutputWriter.TraverseFolder(@input);
    }
}

