using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devision
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            while (n < 1 || n > 1000)
            {
                Console.Write("Input a number between 1 and 1000: ");
                n = int.Parse(Console.ReadLine());
                if (n < 1 || n > 1000)
                    Console.WriteLine("Invalid input. Try again!");
            }
            double p1 = 0.0, p2 = 0.0, p3 = 0.0;
            int[] nums = new int[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
                if (nums[i]%2 == 0)
                    p1++;
                
                if (nums[i]%3 == 0)
                    p2++;
                
                if (nums[i]%4 == 0)
                    p3++;
            }
            Console.WriteLine(Math.Round((p1 / n * 100), 2) + "%");
            Console.WriteLine(Math.Round((p2 / n * 100), 2) + "%");
            Console.WriteLine(Math.Round((p3 / n * 100), 2) + "%");
        }
    }
}
