using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split_by_Word_Casing
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = new char[] { ',', ';', '.', ':', '!', '(', ')', '\'', '\"', '\\', '/', '[', ']', ' ' };
            List<string> words = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            var lowerCaseWords = new List<string>();
            var mixedCaseWords = new List<string>();
            var upperCaseWords = new List<string>();
            foreach(var word in words)
            {
                switch (checkCase(word))
                {
                    case "lower":
                        lowerCaseWords.Add(word);
                        break;
                    case "upper":
                        upperCaseWords.Add(word);
                        break;
                    case "mixed":
                        mixedCaseWords.Add(word);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Lower-case: {0}", string.Join(", ", lowerCaseWords));
            Console.WriteLine("Mixed-case: {0}", string.Join(", ", mixedCaseWords));
            Console.WriteLine("Upper-case: {0}", string.Join(", ", upperCaseWords));
        }
        static string checkCase(string word)
        {            
            if (char.IsLower(word[0]))
            {
                for (int i = 1; i < word.Length; i++)
                {
                    if (!char.IsLower(word[i]))
                        return "mixed";
                }
                return "lower";
            }
            else if (char.IsUpper(word[0]))
            {
                for (int i = 1; i < word.Length; i++)
                {
                    if (!char.IsUpper(word[i]))
                        return "mixed";
                }
                return "upper";
            }
            else
            {
                return "mixed";
            }
            
            
        }
    }
}
