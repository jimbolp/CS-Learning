using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] pairs = new int[n];
            char equal = 'y';
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    pairs[i] += int.Parse(Console.ReadLine());
                }                 
            }
            int temp = pairs[0];
            Array.Sort(pairs);
            for(int i = 0; i < n; i++)
            {
                if (temp != pairs[i])
                    equal = 'n';
            }
            if (equal == 'y')
                Console.WriteLine("Yes, value = " + temp);
            else
                Console.WriteLine("No, maxdiff = " + (pairs.Last() - pairs[0]));

        }
    }
}
