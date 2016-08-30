using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Christmas_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i <= n; i++)
            {                
                for (int j = n; j > i; j--)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k <= (i*2); k++)
                {
                    if (k == i)
                        Console.Write(" | ");
                    else
                        Console.Write("*");
                }               
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
