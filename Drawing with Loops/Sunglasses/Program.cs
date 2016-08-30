using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunglasses
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                if(i == 0 || i == n-1)
                {
                    for(int j = 0; j < (n*2); j++)
                    {
                        Console.Write("*");
                    }
                    for(int j = 0; j < n; j++)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 0; j < (n * 2); j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
                else
                {
                    for(int j = 0; j < (n*2); j++)
                    {
                        if (j == 0 || j == (n * 2) - 1)
                        {
                            Console.Write("*");
                        }
                        else
                            Console.Write("\\");
                    }
                    for (int j = 0; j < n; j++)
                    {
                        if (i == (n / 2)-1)
                            Console.Write("\\");
                        else
                            Console.Write(" ");
                    }
                    for (int j = 0; j < (n * 2); j++)
                    {
                        if (j == 0 || j == (n * 2) - 1)
                        {
                            Console.Write("*");
                        }
                        else
                            Console.Write("\\");
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
