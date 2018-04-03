using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum__Min__Max__First__Last__Average
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] nums = new int[n];
            for(int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Sum = " + nums.Sum() + "\nMin = " + nums.Min() + "\nMax = " + nums.Max() 
                              + "\nFirst = " + nums.First() + "\nLast = " + nums.Last() + "\nAverage = " + nums.Average());
        }
    }
}
