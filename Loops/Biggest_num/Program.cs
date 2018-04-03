using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biggest_num
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            /*for (int i = 0; i < a.Length; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(a.Max());/**/
            int max = 0;
            for (int i = 0; i < a.Length; i++)
            {                
                a[i] = int.Parse(Console.ReadLine());
                if (i == 0)
                    max = a[i];
                else if (max < a[i])
                    max = a[i];
            }
            Console.WriteLine(max);
        }
    }
}
