using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;
            for(int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                    sum2 += int.Parse(Console.ReadLine());
                else
                    sum1 += int.Parse(Console.ReadLine());
            }
            if (sum1 == sum2)
                Console.WriteLine("Yes " + sum1);
            else
                Console.WriteLine("No\n" + "Diff = " + Math.Abs(sum1 - sum2));

        }
    }
}
