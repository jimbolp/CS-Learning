using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
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
            double p1 = 0.0, p2 = 0.0, p3 = 0.0, p4 = 0.0, p5 = 0.0;
            int[] nums = new int[n];
            for(int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
                if(nums[i] < 200)
                {
                    p1++;
                }
                else if(nums[i] < 400)
                {
                    p2++;
                }
                else if(nums[i] < 600)
                {
                    p3++;
                }
                else if(nums[i] < 800)
                {                    
                    p4++;
                }
                else
                {                    
                    p5++;
                }
            }
            Console.WriteLine(Math.Round((p1 / n * 100), 2) + "%");
            Console.WriteLine(Math.Round((p2 / n * 100), 2) + "%");
            Console.WriteLine(Math.Round((p3 / n * 100), 2) + "%");
            Console.WriteLine(Math.Round((p4 / n * 100), 2) + "%");
            Console.WriteLine(Math.Round((p5 / n * 100), 2) + "%");
        }
    }
}
