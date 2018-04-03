using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PairsByDifference
{
    static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int sum = int.Parse(Console.ReadLine());
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i; j < arr.Length; j++)
            {
                if (Math.Abs(arr[i] - arr[j]) == sum)
                {
                    count++;
                }
            }
        }
        Console.WriteLine(count);
    }
}

