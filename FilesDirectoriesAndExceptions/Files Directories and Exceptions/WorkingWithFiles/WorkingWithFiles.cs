using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Dynamic;
using System.Linq.Dynamic;

class WorkingWithFiles
{
    static int Main(string[] args)
    {
        //Read all the text from a file, split to take only words and convert all letters to lower case
        string[] words = null;
        try
        {
            words = File.ReadAllText("text.txt").ToLower().Trim()
                .Split(new char[] { ' ', '.', '!', '?', ',', ';', '\r', '\n', '-' },
                StringSplitOptions.RemoveEmptyEntries);
        }catch(Exception e)
        {
            File.WriteAllText("Exception log.txt", e.ToString());
            Console.WriteLine("There's been a problem with reading from file \"text.txt\". \nYou can find more about the problem in \"Exception log.txt\"");
            return -1;
        }

        /*File.WriteAllLines("words.txt", lines);
        string[] words = File.ReadAllText("words.txt").ToLower()
            .Split(new char[] { '\n', '\r' },
            StringSplitOptions.RemoveEmptyEntries);
        //Array.Sort(words);//*/

        int totalWords = 0;
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (wordCount.ContainsKey(word))
            {
                wordCount[word]++;
                totalWords++;
            }
            else
            {
                wordCount[word] = 1;
                totalWords++;
            }
        }
        //Order the Dictionary by Key in ascending order
        wordCount = wordCount.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

        //Order by Value in descending order
        wordCount = wordCount.OrderBy(x => -x.Value).ToDictionary(x => x.Key, x => x.Value);

        //If file already exists delete it's content
        if (File.Exists("CountedWords.txt"))
        {
            File.WriteAllText("CountedWords.txt", "");
        }

        //Place the formated Dictionary in the file
        foreach (var word in wordCount)
        {
            File.AppendAllText("CountedWords.txt", $"{word.Key} -> {word.Value}{Environment.NewLine}");
        }
        File.AppendAllText("CountedWords.txt", $"Total Words in the Text -> {totalWords}.");

        foreach (var word in words)
        {
            Console.WriteLine(string.Join(" ",word));
        }

        if (File.Exists("output.txt"))
        {
            File.WriteAllText("output.txt", "");
        }
        //Numerating the lines in the file
        int numerate = 1;

        for (int i = 0; i < words.Length; i++)
        {            
            File.AppendAllText("output.txt", $"{numerate++}. {words[i]}{Environment.NewLine}");
        }

        Console.WriteLine(new string('-', 50)+ "\n");
        
        Console.WriteLine(string.Join(" ", File.ReadAllText("output.txt")));
        

        string[] countedWords = File.ReadAllLines("CountedWords.txt");

        foreach (var line in countedWords)
        {
            Console.WriteLine(string.Join(" ",line));
        }

        return 0;
    }
}

