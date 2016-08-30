using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Left_and_Right
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
                sum1 += int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                sum2 += int.Parse(Console.ReadLine());
            }
            if (sum1 == sum2)
                Console.WriteLine("Yes " + sum1);
            else
                Console.WriteLine("No, diff " + Math.Abs(sum1 - sum2));
        }
    }
}
