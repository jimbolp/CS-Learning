using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LargestCommonEnd
{
    static void Main(string[] args)
    {
        var firstString = Console.ReadLine().Split(' ').ToList();
        var secondString = Console.ReadLine().Split(' ').ToList();
        List<string> commonBegining = new List<string>();
        List<string> commonEnd = new List<string>();
        if (firstString[0] == secondString[0])
        {
            for (int i = 0;
                i < (firstString.Count < secondString.Count ? firstString.Count : secondString.Count);
                i++)
            {
                if (firstString[i] == secondString[i])
                    commonBegining.Add(firstString[i]);
                else
                {
                    break;
                }
            }
        }
        if (firstString[firstString.Count - 1] == secondString[secondString.Count - 1])
        {
            for (int i = firstString.Count-1, j = secondString.Count-1; (firstString.Count < secondString.Count ? i > 0 : j > 0); i--, j--)
            {
                if (firstString[i] == secondString[j])
                    commonEnd.Add(firstString[i]);
            }
        }
        if (commonBegining.Count > commonEnd.Count)
        {
            Console.WriteLine("The largest common end is at the left: " + string.Join(" ",commonBegining));
        }
        else if(commonBegining.Count == 0 && commonEnd.Count == 0)
            Console.WriteLine("No common words at the left and right");
        else
        {
            List<string> temp = new List<string>();
            for(int i = commonEnd.Count-1; i > 0; i--)
                temp.Add(commonEnd[i]);
            Console.WriteLine("The largest common end is at the right: " + string.Join(" ",temp));
        }
        

    }
}

