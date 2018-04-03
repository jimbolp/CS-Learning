using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FoldAndSum
{
    static void Main(string[] args)
    {
        int[] arr = new int[1];
        while (arr.Length % 4 != 0)
            arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int partLength = arr.Length/4;
        int[] foldedInts = new int[arr.Length/2];
        for (int i = 0; i < partLength; i++)
        {
            foldedInts[i] = arr[partLength - 1 - i];
        }
        for (int i = arr.Length-1, j = 0; j < partLength; i--, j++)
        {
            foldedInts[partLength + j] = arr[i];
        }
        int[] middle = new int[arr.Length/2];
        for (int i = partLength, j = 0; i < arr.Length - partLength; i++, j++)
        {
            middle[j] = arr[i];
        }
        for (int i = 0; i < middle.Length; i++)
        {
            middle[i] += foldedInts[i];
        }
        Console.WriteLine(string.Join(" ", middle));
    }
}
