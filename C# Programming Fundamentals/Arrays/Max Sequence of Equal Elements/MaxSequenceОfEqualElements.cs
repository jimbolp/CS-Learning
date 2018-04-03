using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MaxSequenceОfEqualElements
{
    static void Main(string[] args)
    {
        //Много тъп алгоритъм :D :D

        int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        
        int max = 0;
        int maxInt = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            int count = 0;
            int temp = arr[i];
            int j = i;
            while (j < arr.Length && temp == arr[j])
            {
                count++;
                j++;
            }
            i = j-1;
            if (max < count)
            {
                maxInt = arr[i];
                max = count;
            }
        }
        Console.WriteLine(maxInt);
    }
}

