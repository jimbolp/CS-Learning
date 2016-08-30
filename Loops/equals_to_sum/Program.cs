using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equals_to_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] nums = new int[n];
            int max = 0;
            int sum = 0;
            for(int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
                if (i == 0 || max < nums[i])
                    max = nums[i];
                sum += nums[i];
            }
            if(max == (sum - max))
            {
                Console.WriteLine("Yes\nSum = " + (sum-max));
            }
            else
            {
                Console.WriteLine("No\nDiff = " + Math.Abs(max-(sum - max)));                
            }
        }
    }
}
